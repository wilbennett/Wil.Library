using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wil.Core;
using Wil.Core.Interfaces;
using Wil.Reactive.Interfaces;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static void OnNextIf<T>(this Subject<T> subject, bool condition, T item)
        {
            if (!condition) return;

            subject.OnNext(item);
        }

        public static void OnNextIf<T>(this Subject<T> subject, Func<bool> predicate, T item)
        {
            if (!predicate()) return;

            subject.OnNext(item);
        }

        public static IObservable<T> Initially<T>(this IObservable<T> source, Action onSubscribe)
        {
            return Observable.Create<T>(o =>
            {
                try
                {
                    onSubscribe();
                    return source.Subscribe(o);
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                    return Disposable.Empty;
                }
            });
        }

        public static IObservable<EventPattern<T>> ObservableEvents<T>(this object source, string eventName)
            => Observable.FromEventPattern<T>(source, eventName);

        public static IObservable<T> ObservableEventArgs<T>(this object source, string eventName)
            => ObservableEvents<T>(source, eventName).Select(m => m.EventArgs);

        public static IObservable<T> ToObservable<T>(
            this IEnumerable<T> items,
            Duration period,
            IScheduler scheduler)
            => Observable.Defer(() => items.ToObservable().LimitTo(1, period, scheduler));

        public static IObservable<T> ToObservable<T>(this IEnumerable<T> items, Duration period)
            => ToObservable(items, period, Scheduler.Default);

        public static IObservable<T> ToObservable<T>(
            this IEnumerable<T> items,
            Duration minPeriod,
            Duration maxPeriod,
            IScheduler scheduler)
            => Observable.Defer(() => items.ToObservable().LimitTo(minPeriod, maxPeriod, scheduler));

        public static IObservable<T> ToObservable<T>(this IEnumerable<T> items,
            Duration minPeriod,
            Duration maxPeriod)
            => ToObservable(items, minPeriod, maxPeriod, Scheduler.Default);

        public static IObservable<Unit> ToObservable(this CancellationToken cancelToken)
        {
            return Observable.Create<Unit>(o =>
            {
                cancelToken.Register(() =>
                {
                    o.OnNext(Unit.Default);
                    o.OnCompleted();
                });

                return Disposable.Empty;
            });
        }

        public static IObservable<Unit> ToObservable(this CancellationTokenSource cancelSource)
            => cancelSource.Token.ToObservable();

        //public static QueuedObservable<T> ToQueue<T>(
        //    this IObservable<T> source,
        //    Action<Exception> onError = null)
        //    => new QueuedObservable<T>(source, onError);

        //public static IObservable<T> ToObservableQueue<T>(this IObservable<T> source)
        //{
        //    return Observable.Create<T>(o =>
        //    {
        //        var queue = source.ToQueue(o.OnError);
        //        var sub = queue.ToObservable().Subscribe(o);

        //        return new CompositeDisposable(sub, queue);
        //    });
        //}

        public static IEnumerable<List<T>> CollectList<T>(this IObservable<T> source)
        {
            return source.Collect(
                () => new List<T>(),
                (list, x) => { list.Add(x); return list; },
                list => new List<T>());
        }

        public static IObservable<T> Nest<T>(
            this IObservable<T> source,
            Func<T, bool> unnestPredicate,
            T defaultValue = default(T))
        {
            return Observable.Create<T>(o =>
            {
                var stack = new Stack<T>();

                return source
                    .Subscribe(x =>
                    {
                        if (!unnestPredicate(x))
                        {
                            stack.Push(x);
                            o.OnNext(x);
                            return;
                        }

                        if (stack.Count < 1)
                        {
                            o.OnError(new Exception("Unbalanced nesting."));
                            return;
                        }

                        stack.Pop();
                        o.OnNext(stack.Count > 0 ? stack.Peek() : defaultValue);
                    },
                    o.OnError,
                    () =>
                    {
                        if (stack.Count != 0)
                            o.OnError(new Exception("Completed with unbalanced nesting."));

                        o.OnCompleted();
                    });
            });
        }

        public static IObservable<string> Nest(this IObservable<string> source)
            => Nest(source, string.IsNullOrWhiteSpace, string.Empty);

        public static IObservable<TOutput> GroupScan<TKey, TInput, TOutput>(
            this IObservable<TInput> observable,
            Func<TInput, TKey> keySelector,
            Func<TKey, TOutput> factory,
            Func<TInput, TOutput, TOutput> accumulator,
            TimeSpan groupLifetime)
        {
            return observable
                .GroupByUntil(keySelector, _ => Observable.Timer(groupLifetime))
                .SelectMany
                (
                    grp =>
                    {
                        TOutput output = factory(grp.Key);
                        return grp.Select(input => accumulator(input, output));
                    }
                );
        }

        private static void Ignore<T>(T value) { }
    }
}
