using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Wil.Core;
using Wil.Core.Interfaces;
using Wil.Core.Interfaces.Extensions;
using Wil.Reactive.Interfaces;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static IObservable<Rate> Measure<T>(this IObservable<T> source, ISpeedometer speedometer = null)
        {
            return Observable.Create<Rate>(o =>
            {
                speedometer = speedometer ?? new Speedometer(1.Second(), Scheduler.Default);
                var emptyRate = new Rate(-1, 0);

                IDisposable sub = source
                    .TimeoutScan(
                        speedometer.Period,
                        () =>
                        {
                            speedometer.Update(0);
                            return speedometer.Rate;
                        },
                        x => speedometer.Update() ? speedometer.Rate : emptyRate,
                        speedometer.Scheduler)
                    .DistinctUntilChanged()
                    .Where(r => r.Count >= 0)
                    .Subscribe(o);

                return sub;
            });
        }

        public static IObservable<RateEvent<T>> MeasureScan<T>(this IObservable<T> source, ISpeedometer speedometer)
        {
            return Observable.Create<RateEvent<T>>(o =>
            {
                speedometer = speedometer ?? new Speedometer(1.Second(), Scheduler.Default);

                IDisposable sub = source
                    .TimeoutScan(
                        speedometer.Period,
                        () =>
                        {
                            speedometer.Update(0);
                            return new RateEvent<T>(speedometer.Rate);
                        },
                        x =>
                        {
                            speedometer.Update(1, true);
                            return new RateEvent<T>(x, speedometer.Rate);
                        },
                        speedometer.Scheduler)
                    .Subscribe(o);

                return sub;
            });
        }

        /*
        // Pro: Simple. No Do().
        // Con: Boxing. Publish source. New timer each item (probably what Throttle does anyway). Subject to remove extra wait (Rate) on complete.
        public static IObservable<Rate> Measure<T>(this IObservable<T> source, ISpeedometer speedometer)
        {
            return Observable.Create<Rate>(o =>
            {
                speedometer = speedometer ?? new Speedometer(1.Second(), Scheduler.Default);
                var emptyRate = new Rate(-1, 0);
                var timerObject = new object();
                var startObject = new object();

                IObservable<object> timer = Observable.Timer(speedometer.Period, speedometer.Scheduler)
                    .Select(_ => timerObject);

                IConnectableObservable<object> sourceObjects = source
                    //.Do(x => Console.WriteLine($"##### Got {x} at {speedometer.Scheduler.Now.TimeOfDay}"))
                    .Select(x => (object)x)
                    .Publish();

                var sourceComplete = new Subject<Unit>();

                IDisposable completeSub = sourceObjects
                    .Subscribe(Ignore, o.OnError, () => sourceComplete.OnNext(Unit.Default));

                IDisposable sub = sourceObjects
                    .StartWith(startObject)
                    .SelectMany(x => Observable.Return(x).Concat(timer.TakeUntil(sourceObjects)))
                    .Select(w =>
                    {
                        if (ReferenceEquals(w, startObject)) return emptyRate;

                        if (ReferenceEquals(w, timerObject))
                        {
                            //Console.WriteLine($"@@@@@ stale at {speedometer.Scheduler.Now.TimeOfDay} *****");
                            speedometer.Update(0);
                            return speedometer.Rate;
                        }

                        return speedometer.Update() ? speedometer.Rate : emptyRate;
                    })
                    .Where(r => r.Count >= 0)
                    .DistinctUntilChanged()
                    .TakeUntil(sourceComplete)
                    .Subscribe(o);

                return new CompositeDisposable(sub, completeSub, sourceObjects.Connect());
            });
        }
        //*/

        #region Alternative Implementations
        /*
        // Pro: Simple. One explicit subscription to source
        // Con: Using Do(). Boxing. New subject. Synchronization on results subject.
        public static IObservable<Rate> Measure<T>(this IObservable<T> source, ISpeedometer speedometer)
        {
            return Observable.Create<Rate>(o =>
            {
                speedometer = speedometer ?? new Speedometer(1.Second(), Scheduler.Default);
                Console.WriteLine($"***** Throttle period {speedometer.Period}");
                var emptyRate = new Rate(-1, 0);
                var timerObject = new object();
                var results = new Subject<object>();

                IDisposable resultsSub = results
                    .Synchronize()
                    .Select(w =>
                    {
                        if (ReferenceEquals(w, timerObject))
                        {
                            Console.WriteLine($"@@@@@ stale at {speedometer.Scheduler.Now.TimeOfDay} *****");
                            speedometer.Update(0);
                            return speedometer.Rate;
                        }

                        return speedometer.Update() ? speedometer.Rate : emptyRate;
                    })
                    .Where(r => r.Count >= 0)
                    .DistinctUntilChanged()
                    .Subscribe(o);

                IDisposable sub = source
                    .Do(x => Console.WriteLine($"##### Got {x} at {speedometer.Scheduler.Now.TimeOfDay}"))
                    .Do(x => results.OnNext(x))
                    //.Do(x => Console.WriteLine($"&&&&& updating on {x} at {speedometer.Scheduler.Now.TimeOfDay}"))
                    .StartWith(default(T))
                    .Throttle(speedometer.Period, speedometer.Scheduler)
                    .Subscribe(_ => results.OnNext(timerObject), o.OnError, () => results.OnCompleted());

                return new CompositeDisposable(sub, resultsSub, results);
            });
        }
        //*/

        /*
        // Pro: Simple. No Do().
        // Con: Boxing. New cancellation source and token. New subject. Synchronization on results subject.

        public static IObservable<Rate> Measure<T>(this IObservable<T> source, ISpeedometer speedometer)
        {
            return Observable.Create<Rate>(o =>
            {
                speedometer = speedometer ?? new Speedometer(1.Second(), Scheduler.Default);
                var cts = new CancellationTokenSource();
                var emptyRate = new Rate(-1, 0);
                var timerObject = new object();
                var results = new Subject<object>();

                IDisposable resultsSub = results
                    .Synchronize()
                    .Select(w =>
                    {
                        if (ReferenceEquals(w, timerObject))
                        {
                            Console.WriteLine($"@@@@@ stale at {speedometer.Scheduler.Now.TimeOfDay} *****");
                            speedometer.Update(0);
                            return speedometer.Rate;
                        }

                        return speedometer.Update() ? speedometer.Rate : emptyRate;
                    })
                    .Where(r => r.Count >= 0)
                    .DistinctUntilChanged()
                    .Subscribe(o);

                void processStale(T x, CancellationToken c)
                {
                    if (c.IsCancellationRequested) return;
                    results.OnNext(timerObject);
                }

                void ScheduleStale(T x)
                {
                    cts.Cancel();
                    cts = new CancellationTokenSource();
                    var ct = cts.Token;
                    speedometer.Scheduler.Schedule(speedometer.Period, () => processStale(x, ct));
                }

                ScheduleStale(default(T));

                IDisposable sub = source
                    .Do(x => Console.WriteLine($"##### Got {x} at {speedometer.Scheduler.Now.TimeOfDay}"))
                    .Subscribe(x =>
                    {
                        ScheduleStale(x);
                        results.OnNext(x);
                    },
                    o.OnError,
                    () => results.OnCompleted());

                return new CompositeDisposable(sub, resultsSub, results);
            });
        }
        //*/
        #endregion

        public static IObservable<Rate> Measure<T>(
            this IObservable<T> source,
            Duration period,
            IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            var speedometer = new Speedometer(period, scheduler);
            speedometer.Start();
            return Measure(source, speedometer);
        }

        /*
        public static IObservable<RateEvent<T>> MeasureScan<T>(this IObservable<T> source, ISpeedometer speedometer = null)
        {
            return Observable.Create<RateEvent<T>>(o =>
            {
                speedometer = speedometer ?? new Speedometer(1.Second(), Scheduler.Default);
                var emptyRateEvent = new RateEvent<T>(-1, 0);
                var timerObject = new object();
                var startObject = new object();

                IObservable<object> timer = Observable.Timer(speedometer.Period, speedometer.Scheduler)
                    .Select(_ => timerObject);

                IConnectableObservable<object> sourceObjects = source
                    //.Do(x => Console.WriteLine($"##### Got {x} at {speedometer.Scheduler.Now.TimeOfDay}"))
                    .Select(x => (object)x)
                    .Publish();

                var sourceComplete = new Subject<Unit>();

                IDisposable completeSub = sourceObjects
                    .Subscribe(Ignore, o.OnError, () => sourceComplete.OnNext(Unit.Default));

                IDisposable sub = sourceObjects
                    .StartWith(startObject)
                    .SelectMany(x => Observable.Return(x).Concat(timer.TakeUntil(sourceObjects)))
                    .Select(w =>
                    {
                        if (ReferenceEquals(w, startObject)) return emptyRateEvent;

                        if (ReferenceEquals(w, timerObject))
                        {
                            //Console.WriteLine($"@@@@@ stale at {speedometer.Scheduler.Now.TimeOfDay} *****");
                            speedometer.Update(0);
                            return new RateEvent<T>(speedometer.Rate);
                        }

                        speedometer.Update(1, true);
                        return new RateEvent<T>((T)w, speedometer.Rate);
                    })
                    .Where(r => r.Count >= 0)
                    .TakeUntil(sourceComplete)
                    .Subscribe(o);

                return new CompositeDisposable(sub, completeSub, sourceObjects.Connect());
            });
        }
        //*/

        public static IObservable<RateEvent<T>> MeasureScan<T>(
            this IObservable<T> source,
            Duration period,
            IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            var speedometer = new Speedometer(period, scheduler);
            speedometer.Start();
            return MeasureScan(source, speedometer);
        }

        // NOTE: Works with discreet intervals.  Needs refactoring to work with rolling/continuous intervals.
        public static IObservable<T> LimitTo<T, TPeriod>(
            this IObservable<T> source,
            int count,
            IObservable<TPeriod> periodSource,
            IScheduler scheduler = null)
        {
            return Observable.Create<T>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                var sem = new SemaphoreSlim(0, count);
                var queue = new ConcurrentQueue<T>();
                var queueComplete = new Subject<Unit>();
                bool isSourceComplete = false;
                IConnectableObservable<T> publishedSource = source.Publish();

                IDisposable sourceSub = publishedSource
                    .Finally(() => isSourceComplete = true)
                    .Subscribe(Ignore, o.OnError);

                IObservable<Unit> timer = periodSource
                    .TakeUntil(queueComplete)
                    .Select(_ =>
                    {
                        sem.ReleaseMax(count);
                        return (Unit.Default);
                    });

                bool GetNext(out T value)
                {
                    value = default(T);

                    if (queue.IsEmpty)
                    {
                        if (isSourceComplete)
                            queueComplete.OnNext(Unit.Default);

                        return false;
                    }

                    return sem.Wait(0) && queue.TryDequeue(out value);
                }

                IEnumerable<T> GetQueueValues(Unit dummy)
                {
                    while (GetNext(out T value))
                        yield return value;
                }

                IDisposable sub = publishedSource
                    .Select(x =>
                    {
                        queue.Enqueue(x);
                        return Unit.Default;
                    })
                    .Merge(timer, scheduler)
                    .SelectMany(GetQueueValues)
                    .Subscribe(o);

                return new CompositeDisposable(sub, sourceSub, publishedSource.Connect(), queueComplete, sem);
            });
        }

        public static IObservable<T> LimitTo<T>(
            this IObservable<T> source,
            int count,
            Duration period,
            IScheduler scheduler = null)
            => LimitTo(source, count, Observable.Timer(TimeSpan.Zero, period, scheduler ?? Scheduler.Default), scheduler);

        public static IObservable<T> LimitTo<T>(this IObservable<T> source, Rate rate, IScheduler scheduler = null)
            => LimitTo(source, (int)rate.Count, rate.Period, scheduler);

        public static IObservable<T> LimitTo<T>(
            this IObservable<T> source,
            Func<Duration> periodSelector,
            IScheduler scheduler = null)
        {
            return Observable.Create<T>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                var sem = new SemaphoreSlim(1, 1);
                var queue = new Queue<T>();
                var work = new SerialDisposable();
                var subscription = new CancellationDisposable();
                bool isSourceComplete = false;
                bool workScheduled = false;

                IDisposable sourceSub = source
                    .ObserveOn(scheduler)
                    .Finally(() => isSourceComplete = true)
                    .Subscribe(
                    x =>
                    {
                        queue.Enqueue(x);
                        ScheduleWork(false, Duration.Zero);
                    },
                    o.OnError);

                void ScheduleWork(bool releaseSemaphore, Duration dueTime)
                {
                    if (workScheduled) return;

                    workScheduled = true;

                    work.Disposable = dueTime == Duration.Zero
                        ? scheduler.Schedule(() => DoWork(releaseSemaphore))
                        : scheduler.Schedule(dueTime, () => DoWork(releaseSemaphore));
                }

                void DoWork(bool releaseSemaphore)
                {
                    try
                    {
                        workScheduled = false;

                        if (subscription.Token.IsCancellationRequested) return;

                        if (releaseSemaphore)
                            sem.ReleaseMax(1);

                        if (queue.Count == 0)
                        {
                            if (isSourceComplete)
                                o.OnCompleted();

                            return;
                        }

                        // Should never fail.  We release after each OnNext.
                        if (!sem.Wait(0)) throw new Exception("Unexpected error getting next item.");

                        T value = queue.Dequeue();
                        o.OnNext(value);
                        ScheduleWork(true, periodSelector());
                    }
                    catch (Exception ex)
                    {
                        o.OnError(ex);
                    }
                }

                return new CompositeDisposable(subscription, sourceSub, work, sem);
            });
        }

        public static IObservable<T> LimitTo<T>(
            this IObservable<T> source,
            Duration period,
            IScheduler scheduler = null)
            => LimitTo(source, () => period, scheduler);

        public static IObservable<T> LimitTo<T>(
            this IObservable<T> source,
            Duration minPeriod,
            Duration maxPeriod,
            IScheduler scheduler = null)
            => LimitTo(source, new RandomDuration(minPeriod, maxPeriod).Next, scheduler);

        public static IObservable<T> ThrottleTo<T, TPeriod>(
            this IObservable<T> source,
            int count,
            IObservable<TPeriod> periodSource,
            IScheduler scheduler = null)
        {
            return Observable.Create<T>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                var sem = new SemaphoreSlim(0, count);

                IDisposable periodSub = periodSource
                    .Subscribe(_ => sem.ReleaseMax(count), o.OnError);

                IDisposable sub = source
                    .Where(_ => sem.Wait(0))
                    .Subscribe(o);

                return new CompositeDisposable(sub, periodSub, sem);
            });
        }

        public static IObservable<T> ThrottleTo<T>(
            this IObservable<T> source,
            int count,
            Duration period,
            IScheduler scheduler = null)
            => ThrottleTo(source, count, Observable.Timer(TimeSpan.Zero, period, scheduler ?? Scheduler.Default), scheduler);

        public static IObservable<T> ThrottleTo<T>(this IObservable<T> source, Rate rate, IScheduler scheduler = null)
            => ThrottleTo(source, (int)rate.Count, rate.Period, scheduler);
    }
}
