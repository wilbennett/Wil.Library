using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Wil.Core.Interfaces;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static IObservable<long> RandomTimer(
            Duration dueTime,
            Duration minPeriod,
            Duration maxPeriod,
            IScheduler scheduler = null)
        {
            return Observable.Create<long>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                var rand = new RandomDuration(minPeriod, maxPeriod);
                long value = 0;

                IObservable<long> initial = Observable.Timer(dueTime, scheduler).Select(_ => value++);

                IObservable<long> rest =
                    Observable.Return(0, scheduler)
                    .SelectMany(_ => Observable.Timer(TimeSpan.FromMilliseconds(rand.Next()), scheduler))
                    .Select(_ => value++)
                    .Repeat();

                return initial.Concat(rest).Subscribe(o);
            });
        }

        public static IObservable<long> ResetTimer<T>(
            Duration dueTime,
            Duration period,
            IObservable<T> resetSource,
            IScheduler scheduler = null)
        {
            return Observable.Create<long>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                long value = 0;

                IConnectableObservable<object> sourceObject = resetSource.Select(x => (object)x).Publish();
                var sourceComplete = new Subject<Unit>();

                IDisposable completeSub = sourceObject
                    .Subscribe(_ => { }, o.OnError, () => sourceComplete.OnNext(Unit.Default));

                IObservable<object> timer = Observable.Timer(period, scheduler).Select(_ => _timerObject);

                IDisposable sub = Observable.Timer(dueTime, scheduler).TakeUntil(sourceObject).Select(_ => _timerObject)
                    .Merge(sourceObject)
                    .SelectMany(
                        x => ReferenceEquals(x, _timerObject)
                            ? Observable.Return(x)
                            : timer.TakeUntil(sourceObject))
                    .TakeUntil(sourceComplete)
                    .Select(_ => value++)
                    .Subscribe(o);

                return new CompositeDisposable(sub, completeSub, sourceObject.Connect());
            });
        }

        public static IObservable<TResult> Timeout<T, TResult>(
            this IObservable<T> source,
            Duration period,
            Func<TResult> timeoutValueFactory,
            IScheduler scheduler = null)
        {
            return Observable.Create<TResult>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;

                IConnectableObservable<object> sourceObject = source.Select(x => (object)x).Publish();
                var sourceComplete = new Subject<Unit>();

                IDisposable completeSub = sourceObject
                    .Subscribe(_ => { }, o.OnError, () => sourceComplete.OnNext(Unit.Default));

                IObservable<object> timer = Observable.Timer(period, scheduler).Select(_ => _timerObject);

                IDisposable sub = sourceObject
                    .StartWith(_startObject)
                    .SelectMany(x => ReferenceEquals(x, _timerObject) ? Observable.Return(x) : timer.TakeUntil(sourceObject))
                    .TakeUntil(sourceComplete)
                    .Select(_ => timeoutValueFactory())
                    .Subscribe(o);

                return new CompositeDisposable(sub, completeSub, sourceObject.Connect());
            });
        }

        public static IObservable<TResult> Timeout<T, TResult>(
            this IObservable<T> source,
            Duration period,
            TResult timeoutValue,
            IScheduler scheduler = null)
            => Timeout(source, period, () => timeoutValue, scheduler);

        public static IObservable<TResult> TimeoutScan<T, TResult>(
            this IObservable<T> source,
            Duration period,
            Func<TResult> timeoutValueFactory,
            Func<T, TResult> resultSelector,
            IScheduler scheduler = null)
        {
            return Observable.Create<TResult>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;

                IConnectableObservable<object> sourceObject = source.Select(x => (object)x).Publish();
                var sourceComplete = new Subject<Unit>();

                IDisposable completeSub = sourceObject
                    .Subscribe(_ => { }, o.OnError, () => sourceComplete.OnNext(Unit.Default));

                IObservable<object> timer = Observable.Timer(period, scheduler).Select(_ => _timerObject);

                IDisposable sub = sourceObject
                    .StartWith(_startObject)
                    .SelectMany(x => Observable.Return(x).Concat(timer.TakeUntil(sourceObject).TakeUntil(sourceComplete)))
                    .Where(w => !ReferenceEquals(w, _startObject))
                    .Select(w => ReferenceEquals(w, _timerObject) ? timeoutValueFactory() : resultSelector((T)w))
                    .Subscribe(o);

                return new CompositeDisposable(sub, completeSub, sourceObject.Connect());
            });
        }

        public static IObservable<TResult> TimeoutScan<T, TResult>(
            this IObservable<T> source,
            Duration period,
            TResult timeoutValue,
            Func<T, TResult> resultSelector,
            IScheduler scheduler = null)
            => TimeoutScan(source, period, () => timeoutValue, resultSelector, scheduler);

        public static IObservable<T> TimeoutScan<T>(
            this IObservable<T> source,
            Duration period,
            T timeoutValue,
            IScheduler scheduler = null)
            => TimeoutScan(source, period, timeoutValue, x => x, scheduler);

        private static readonly object _timerObject = new object();
        private static readonly object _startObject = new object();
    }
}
