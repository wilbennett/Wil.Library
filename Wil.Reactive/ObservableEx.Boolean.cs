using System;
using System.Linq;
using System.Reactive.Linq;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static IObservable<bool> Inverse(this IObservable<bool> observable)
            => observable.Select(value => !value);

        public static IObservable<bool> AggregateCombineLatest(
            this IObservable<bool> observable,
            Func<bool, bool, bool> combine,
            params IObservable<bool>[] observables)
            => observables
                .Aggregate(observable, (current, item) => current.CombineLatest(item, combine))
                .DistinctUntilChanged();

        public static IObservable<bool> And(this IObservable<bool> observable, IObservable<bool> other)
            => observable.CombineLatest(other, (x, y) => x && y).DistinctUntilChanged();

        public static IObservable<bool> And(
            this IObservable<bool> observable,
            params IObservable<bool>[] observables)
            => AggregateCombineLatest(observable, (x, y) => x && y, observables).DistinctUntilChanged();

        public static IObservable<bool> AndNot(this IObservable<bool> observable, IObservable<bool> other)
            => observable.CombineLatest(other.Inverse(), (x, y) => x && y).DistinctUntilChanged();

        public static IObservable<bool> AndNot(
            this IObservable<bool> observable,
            params IObservable<bool>[] observables)
            => AggregateCombineLatest(observable, (x, y) => x && !y, observables);

        public static IObservable<bool> Or(this IObservable<bool> observable, IObservable<bool> other)
            => observable.CombineLatest(other, (x, y) => x || y).DistinctUntilChanged();

        public static IObservable<bool> Or(
            this IObservable<bool> observable,
            params IObservable<bool>[] observables)
            => AggregateCombineLatest(observable, (x, y) => x || y, observables);

        public static IObservable<bool> OrNot(this IObservable<bool> observable, IObservable<bool> other)
            => observable.CombineLatest(other.Inverse(), (x, y) => x || y).DistinctUntilChanged();

        public static IObservable<bool> OrNot(
            this IObservable<bool> observable,
            params IObservable<bool>[] observables)
            => AggregateCombineLatest(observable, (x, y) => x || !y, observables);

        public static IObservable<bool> Xor(this IObservable<bool> observable, IObservable<bool> other)
            => observable.CombineLatest(other, (x, y) => x ^ y).DistinctUntilChanged();

        public static IObservable<bool> Xor(
            this IObservable<bool> observable,
            params IObservable<bool>[] observables)
            => AggregateCombineLatest(observable, (x, y) => x ^ y, observables);

        public static IObservable<bool> ReferenceCounted(this IObservable<bool> source)
        {
            return Observable.Create<bool>(o =>
            {
                int count = 0;

                return source
                    .Subscribe(x =>
                    {
                        if (x)
                        {
                            if (count == 0)
                                o.OnNext(x);

                            ++count;
                        }
                        else
                        {
                            --count;

                            if (count == 0)
                                o.OnNext(x);
                        }

                        if (count < 0)
                            o.OnError(new Exception("Unbalanced count."));
                    },
                    o.OnError,
                    () =>
                    {
                        if (count != 0)
                            o.OnError(new Exception("Completed with unbalanced count."));

                        o.OnCompleted();
                    });
            });
        }
    }
}
