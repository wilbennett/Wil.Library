using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;

namespace Wil.Reactive
{
    public static class ReactiveFileUtils
    {
        public static IObservable<IList<byte>> ReadObservableByteBuffer(string filePath, int bufferSize = 4096)
            => File.OpenRead(filePath).ToObservableByteBuffer(bufferSize, true);

        public static IObservable<byte> ReadObservableBytes(string filePath, int bufferSize = 4096)
            => File.OpenRead(filePath).ToObservable(bufferSize, true);

        public static IObservable<string> ReadObservableStrings(string filePath)
        {
            return Observable.Create<string>(async (o, ct) =>
            {
                try
                {
                    using (var file = new StreamReader(filePath, true))
                    {
                        string line = await file.ReadLineAsync().ConfigureAwait(false);

                        while (line != null)
                        {
                            ct.ThrowIfCancellationRequested();
                            o.OnNext(line);
                            line = await file.ReadLineAsync().ConfigureAwait(false);
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

        public static IObservable<IList<char>> ReadObservableCharBuffer(string filePath, int bufferSize = 4096)
        {
            return Observable.Create<IList<char>>(async (o, ct) =>
            {
                try
                {
                    using (var file = new StreamReader(filePath, true))
                    {
                        var buffer = new char[bufferSize];
                        int count;

                        while ((count = await file.ReadAsync(buffer, 0, bufferSize).ConfigureAwait(false)) > 0)
                        {
                            ct.ThrowIfCancellationRequested();
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

        public static IObservable<char> ReadObservableChars(string filePath, int bufferSize = 4096)
            => ReadObservableCharBuffer(filePath, bufferSize).SelectMany(buffer => buffer);
    }
}
