using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Wil.Core.Interfaces;
using Wil.Core.Interfaces.Extensions;

namespace Wil.Core
{
    public class ConcurrentCompleteQueue<T> : IDisposable, IEnumerable<T>
    {
        private bool _isComplete;
        public bool IsComplete
        {
            get => _isComplete;
            protected set
            {
                if (!value) return;
                if (_isComplete == value) return;

                _isComplete = value;
                OnComplete?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler OnComplete;

        public void Complete() => _completeRequested.Cancel();

        public void Enqueue(T value)
        {
            if (_completeRequested.IsCancellationRequested) return;

            _queue.Enqueue(value);
            _haveItem.Set();
        }

        public bool TryDequeue(out T value, Duration timeout)
        {
            _haveItem.Reset();

            if (TryDequeueCore(out value)) return true;
            if (timeout.Value == TimeSpan.Zero) return false;

            try
            {
                if (!_haveItem.Wait(timeout.Value, _completeRequested.Token)) return false;
            }
            catch (OperationCanceledException)
            {
            }

            return TryDequeueCore(out value);
        }

        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private readonly ManualResetEventSlim _haveItem = new ManualResetEventSlim(false);
        private readonly CancellationTokenSource _completeRequested = new CancellationTokenSource();

        private bool TryDequeueCore(out T value)
        {
            if (_queue.TryDequeue(out value)) return true;

            if (_completeRequested.IsCancellationRequested && _queue.IsEmpty)
                IsComplete = true;

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Duration timeout = 100.Milliseconds();

            while (!IsComplete)
            {
                if (TryDequeue(out T value, timeout))
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region IDisposable Support
        protected bool _isDisposed = false; // To detect redundant calls

        protected virtual void DisposeManagedResources()
        {
            IsComplete = true;
            _haveItem.Dispose();
            _completeRequested.Dispose();
        }

        protected void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    DisposeManagedResources();

                // Free unmanaged resources (unmanaged objects) and override finalizer.
                // Set large fields to null.
                _isDisposed = true;
            }
        }

        public void Dispose() => Dispose(true);
        #endregion
    }
}
