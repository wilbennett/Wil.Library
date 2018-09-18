/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Wil.Core;

namespace Wil.Reactive
{
    public class QueuedObservable<T> : ConcurrentCompleteQueue<T>
    {
        public QueuedObservable(IObservable<T> source, Action<Exception> onError = null)
        {
            _sourceSubscription = source.Subscribe(
                Enqueue,
                ex =>
                {
                    Complete();
                    onError?.Invoke(ex);
                },
                Complete);
        }

        protected override void DisposeManagedResources()
        {
            _sourceSubscription.Dispose();

            base.DisposeManagedResources();
        }

        private readonly IDisposable _sourceSubscription;
    }
}
//*/
