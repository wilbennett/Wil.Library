using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Wil.Reactive
{
    public static partial class ObservableEx
    {
        public static IObservable<IList<byte>> ToObservableByteBuffer(this Stream source, int bufferSize = 4096, bool closeStream = false)
        {
            return Observable.Create<IList<byte>>(async (o, ct) =>
            {
                try
                {
                    IDisposable streamDisposable = closeStream ? source : Disposable.Empty;

                    using (streamDisposable)
                    {
                        var buffer = new byte[bufferSize];
                        int count;

                        while ((count = await source.ReadAsync(buffer, 0, bufferSize, ct)) > 0)
                        {
                            o.OnNext(buffer.Take(count).ToList());
                        }

                        o.OnCompleted();
                    }
                }
                catch (Exception ex)
                {
                    o.OnError(ex);
                }
            });
        }

        public static IObservable<byte> ToObservable(this Stream source, int bufferSize = 4096, bool closeStream = false)
            => ToObservableByteBuffer(source, bufferSize, closeStream).SelectMany(buffer => buffer);
    }
}
