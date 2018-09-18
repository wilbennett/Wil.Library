using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Wil.Core.Interfaces;
using Wil.Reactive.Interfaces;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static IObservable<Stale<T>> DetectStale<T>(this IObservable<T> source, Duration period, IScheduler scheduler = null)
        {
            return Observable.Create<Stale<T>>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                source = source.Publish().RefCount();
                var complete = new Subject<Unit>();
                IDisposable sourceSub = source.Subscribe(_ => { }, o.OnError, () => complete.OnNext(Unit.Default));

                IDisposable sub = source
                    .StartWith(default(T))
                    .Throttle(period, scheduler)
                    .TakeUntil(complete)
                    .Select(_ => Stale<T>.Empty)
                    .Subscribe(o);

                return new CompositeDisposable(sub, sourceSub, complete);
            });
        }

        public static IObservable<Stale<T>> DetectStaleScan<T>(this IObservable<T> source, Duration period, IScheduler scheduler = null)
        {
            return Observable.Create<Stale<T>>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                source = source.Publish().RefCount();
                var complete = new Subject<Unit>();
                IDisposable sourceSub = source.Subscribe(_ => { }, o.OnError, () => complete.OnNext(Unit.Default));

                IObservable<Stale<T>> sourceStale = source.Select(x => new Stale<T>(x));

                IObservable<Stale<T>> stale = source
                    .StartWith(default(T))
                    .Throttle(period, scheduler)
                    .TakeUntil(complete)
                    .Select(_ => Stale<T>.Empty);

                IDisposable sub = sourceStale.Merge(stale, scheduler).Subscribe(o);

                return new CompositeDisposable(sub, sourceSub, complete);
            });
        }

        public static IObservable<StaleGroup<TGroup, TValue>> DetectStaleGroup<TGroup, TValue>(
            this IObservable<TValue> source, Func<TValue, TGroup> keySelector, Duration period, IScheduler scheduler = null)
        {
            return Observable.Create<StaleGroup<TGroup, TValue>>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                source = source.Publish().RefCount();
                var complete = new Subject<Unit>();
                IDisposable sourceSub = source.Subscribe(_ => { }, o.OnError, () => complete.OnNext(Unit.Default));

                IDisposable sub = source
                    .GroupByUntil(keySelector, grp => grp.Throttle(period, scheduler))
                    .SelectMany(grp => grp.TakeLast(1, scheduler).TakeUntil(complete).Select(x => new StaleGroup<TGroup, TValue>(grp.Key)))
                    .Subscribe(o);

                return new CompositeDisposable(sub, sourceSub, complete);
            });
        }

        public static IObservable<StaleGroup<TGroup, TValue>> DetectStaleGroupScan<TGroup, TValue>(
            this IObservable<TValue> source, Func<TValue, TGroup> keySelector, Duration period, IScheduler scheduler = null)
        {
            return Observable.Create<StaleGroup<TGroup, TValue>>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                source = source.Publish().RefCount();
                var complete = new Subject<Unit>();
                IDisposable sourceSub = source.Subscribe(_ => { }, o.OnError, () => complete.OnNext(Unit.Default));

                IObservable<StaleGroup<TGroup, TValue>> timeout = source
                    .GroupByUntil(keySelector, grp => grp.Throttle(period, scheduler))
                    .SelectMany(grp => grp.TakeLast(1, scheduler).TakeUntil(complete).Select(x => new StaleGroup<TGroup, TValue>(grp.Key)));

                IObservable<StaleGroup<TGroup, TValue>> data = source.Select(x => new StaleGroup<TGroup, TValue>(keySelector(x), x));
                IDisposable sub = data.Merge(timeout, scheduler).Subscribe(o);

                return new CompositeDisposable(sub, sourceSub, complete);
            });
        }
    }
}
