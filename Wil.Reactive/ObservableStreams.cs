using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Wil.Core;

namespace Wil.Reactive
{
    public class ObservableStreams<T> : IObservable<T>
    {
        public IDisposable Subscribe(IObserver<T> observer)
            => _subject.SelectMany(x => x).Subscribe(observer);

        public void Add(IObservable<T> stream)
        {
            var wrappedStream = Wrap(stream);

            lock (_sync)
            {
                _list.Add(stream);
                _subject.OnNext(wrappedStream);
            }
        }

        public void Add(IEnumerable<IObservable<T>> streams)
        {
            lock (_sync)
            {
                _list.AddRange(streams);

                streams.ForEach(stream => _subject.OnNext(Wrap(stream)));
            }
        }

        private readonly object _sync = new object();
        private readonly Subject<IObservable<T>> _subject = new Subject<IObservable<T>>();
        private readonly List<IObservable<T>> _list = new List<System.IObservable<T>>();

        private IObservable<T> Wrap(IObservable<T> stream)
        {
            return Observable.Create<T>(o =>
            {
                return stream
                    .Subscribe(
                        o.OnNext,
                        o.OnError,
                        () => { o.OnCompleted(); Remove(stream); });
            });
        }

        private void Remove(IObservable<T> stream)
        {
            lock (_sync)
            {
                _list.Remove(stream);

                if (_list.Count > 0) return;

                _subject.OnCompleted();
            }
        }
    }
}
