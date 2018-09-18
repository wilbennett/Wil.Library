using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Windows.Threading;

namespace Wil.Reactive.Interfaces
{
    public interface ISchedulerProvider
    {
        IScheduler Default { get; }
        IScheduler CurrentThread { get; }
        IScheduler Immediate { get; }
        IScheduler NewThread { get; }
        IScheduler ThreadPool { get; }
        IScheduler TaskPool { get; }

        IScheduler CreateDispatcherScheduler(Dispatcher dispatcher);
        IScheduler CreateDispatcherScheduler(Dispatcher dispatcher, DispatcherPriority priority);

        IScheduler CreateEventLoopScheduler();
        IScheduler CreateEventLoopScheduler(Func<ThreadStart, Thread> threadFactory);

        IScheduler CreateNewThreadScheduler();
        IScheduler CreateNewThreadScheduler(Func<ThreadStart, Thread> threadFactory);

        IScheduler CreateSynchronizationContextScheduler(SynchronizationContext context);
        IScheduler CreateSynchronizationContextScheduler(SynchronizationContext context, bool alwaysPost);
    }
}
