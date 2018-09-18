using System;
using System.Collections.Concurrent;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static IObservable<TOutput> OutputRestartOnNew<TInput, TOutput>(
            this IObservable<TInput> source,
            Func<TInput, IObservable<TOutput>> output,
            Action initialize,
            Action finalize,
            Action<TInput> starting,
            Action<TInput> stopping,
            IScheduler scheduler = null
        )
        {
            return Observable.Create<TOutput>(o =>
            {
                scheduler = scheduler ?? Scheduler.Default;
                source = source.Publish().RefCount();
                var notifySubject = new Subject<Action>();
                var stopQueue = new ConcurrentQueue<Action>();
                bool isLast = false;
                bool finalized = false;
                IDisposable sourceSub = source.Subscribe(Ignore, o.OnError, () => isLast = true);
                Action<Action> notify = action => notifySubject.OnNext(action);

                Action doFinalize = () =>
                {
                    if (finalized) return;
                    if (!isLast) return;

                    notify(finalize);
                    finalized = true;
                };

                Action processStopQueue = () =>
                {
                    if (stopQueue.TryDequeue(out Action stopCall))
                        notify(stopCall);
                };

                IDisposable notifySub = notifySubject.ObserveOn(scheduler).Subscribe(action => action());
                notify(initialize);

                IDisposable sub = source
                    .ObserveOn(scheduler)
                    .Finally(doFinalize)
                    .Select(x =>
                    {
                        processStopQueue();
                        notify(() => starting(x));
                        stopQueue.Enqueue(() => stopping(x));

                        return output(x).TakeUntil(source);
                    })
                    .SelectMany(obs =>
                    {
                        processStopQueue();
                        return obs;
                    })
                    .Subscribe(
                        o.OnNext,
                        ex =>
                        {
                            doFinalize();
                            notify(() => o.OnError(ex));
                        },
                        () =>
                        {
                            doFinalize();
                            notify(o.OnCompleted);
                        });

                return new CompositeDisposable(sub, notifySub, sourceSub, notifySubject);
            });
        }

        public static IObservable<TOutput> ExecuteRestartOnNew<TInput, TOutput>(
            this IObservable<TInput> source,
            Func<TInput, TOutput> execute,
            Action initialize,
            Action finalize,
            Action<TInput> starting,
            Action<TInput> stopping,
            IScheduler scheduler = null)
        {
            return OutputRestartOnNew(
                source,
                x => Observable.FromAsync(ct => Task.Run(() => execute(x), ct), scheduler ?? Scheduler.Default),
                initialize,
                finalize,
                starting,
                stopping,
                scheduler
                );
        }

        public static IObservable<TOutput> ExecuteRestartOnNew<TInput, TOutput>(
            this IObservable<TInput> source,
            Func<TInput, CancellationToken, TOutput> execute,
            Action initialize,
            Action finalize,
            Action<TInput> starting,
            Action<TInput> stopping,
            IScheduler scheduler = null)
        {
            return OutputRestartOnNew(
                source,
                x => Observable.FromAsync(ct => Task.Run(() => execute(x, ct)), scheduler ?? Scheduler.Default),
                initialize,
                finalize,
                starting,
                stopping,
                scheduler
                );
        }

        public static IObservable<TOutput> ExecuteRestartOnNew<TInput, TOutput>(
            this IObservable<TInput> source,
            Func<TInput, Task<TOutput>> execute,
            Action initialize,
            Action finalize,
            Action<TInput> starting,
            Action<TInput> stopping,
            IScheduler scheduler = null)
        {
            return OutputRestartOnNew(
                source,
                x => Observable.FromAsync(() => execute(x), scheduler ?? Scheduler.Default),
                initialize,
                finalize,
                starting,
                stopping,
                scheduler
                );
        }

        public static IObservable<TOutput> ExecuteRestartOnNew<TInput, TOutput>(
            this IObservable<TInput> source,
            Func<TInput, CancellationToken, Task<TOutput>> execute,
            Action initialize,
            Action finalize,
            Action<TInput> starting,
            Action<TInput> stopping,
            IScheduler scheduler = null)
        {
            return OutputRestartOnNew(
                source,
                x => Observable.FromAsync(ct => execute(x, ct), scheduler ?? Scheduler.Default),
                initialize,
                finalize,
                starting,
                stopping,
                scheduler
                );
        }
    }
}
