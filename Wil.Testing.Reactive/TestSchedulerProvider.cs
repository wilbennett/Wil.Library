/*
using Microsoft.Reactive.Testing;
using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Windows.Threading;
using Wil.Reactive.Interfaces;

namespace Wil.Testing.Reactive
{
    // TODO: Provide proper implementation for EventLoopScheduler.
    public class TestSchedulerProvider : ISchedulerProvider
    {
        IScheduler ISchedulerProvider.Default => Default;
        IScheduler ISchedulerProvider.CurrentThread => CurrentThread;
        IScheduler ISchedulerProvider.Immediate => Immediate;
        IScheduler ISchedulerProvider.NewThread => NewThread;
        IScheduler ISchedulerProvider.ThreadPool => ThreadPool;
        IScheduler ISchedulerProvider.TaskPool => TaskPool;

        IScheduler ISchedulerProvider.CreateDispatcherScheduler(Dispatcher dispatcher)
            => CreateDispatcherScheduler(dispatcher);
        IScheduler ISchedulerProvider.CreateDispatcherScheduler(Dispatcher dispatcher, DispatcherPriority priority)
            => CreateDispatcherScheduler(dispatcher, priority);

        IScheduler ISchedulerProvider.CreateEventLoopScheduler()
            => CreateEventLoopScheduler();
        IScheduler ISchedulerProvider.CreateEventLoopScheduler(Func<ThreadStart, Thread> threadFactory)
            => CreateEventLoopScheduler(threadFactory);

        IScheduler ISchedulerProvider.CreateNewThreadScheduler() => CreateNewThreadScheduler();
        IScheduler ISchedulerProvider.CreateNewThreadScheduler(Func<ThreadStart, Thread> threadFactory)
            => CreateNewThreadScheduler(threadFactory);

        IScheduler ISchedulerProvider.CreateSynchronizationContextScheduler(SynchronizationContext context)
            => CreateSynchronizationContextScheduler(context);
        IScheduler ISchedulerProvider.CreateSynchronizationContextScheduler(SynchronizationContext context, bool alwaysPost)
            => CreateSynchronizationContextScheduler(context, alwaysPost);

        public TestScheduler Default { get; } = new TestScheduler();
        public TestScheduler CurrentThread { get; } = new TestScheduler();
        public TestScheduler Immediate { get; } = new TestScheduler();
        public TestScheduler NewThread { get; } = new TestScheduler();
        public TestScheduler ThreadPool { get; } = new TestScheduler();
        public TestScheduler TaskPool { get; } = new TestScheduler();
        public TestScheduler Dispatcher { get; } = new TestScheduler();
        public TestScheduler EventLoop { get; } = new TestScheduler();
        public TestScheduler SynchronizationContext { get; } = new TestScheduler();

        public TestScheduler CreateDispatcherScheduler(Dispatcher dispatcher) => Dispatcher;
        public TestScheduler CreateDispatcherScheduler(Dispatcher dispatcher, DispatcherPriority priority) => Dispatcher;

        public TestScheduler CreateEventLoopScheduler() => EventLoop;
        public TestScheduler CreateEventLoopScheduler(Func<ThreadStart, Thread> threadFactory) => EventLoop;

        public TestScheduler CreateNewThreadScheduler() => NewThread;
        public TestScheduler CreateNewThreadScheduler(Func<ThreadStart, Thread> threadFactory) => NewThread;

        public TestScheduler CreateSynchronizationContextScheduler(SynchronizationContext context) => SynchronizationContext;
        public TestScheduler CreateSynchronizationContextScheduler(SynchronizationContext context, bool alwaysPost) => SynchronizationContext;
    }
}
//*/
