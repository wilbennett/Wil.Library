using System;
using System.Reactive.Linq;

namespace Wil.Reactive
{
    public static partial class ObservableExErrors
    {
        public static IObservable<T> SuppressSubscriberErrors<T>(this IObservable<T> observable, Action<Exception> handler = null)
        {
            return Observable.Create<T>(o =>
            {
                return observable.Subscribe(x =>
                {
                    try
                    {
                        o.OnNext(x);
                    }
                    catch (Exception ex)
                    {
                        handler?.Invoke(ex);
                    }
                },
                o.OnError,
                o.OnCompleted);
            });
        }

        public static IObservable<T> SuppressErrors<T>(
            this IObservable<T> observable,
            Action<Exception> publishHandler = null,
            Action<Exception> subscribeHandler = null)
        {
            return Observable.Create<T>(o =>
            {
                return observable.Subscribe(x =>
                {
                    try
                    {
                        o.OnNext(x);
                    }
                    catch (Exception ex)
                    {
                        subscribeHandler?.Invoke(ex);
                    }
                },
                ex => publishHandler?.Invoke(ex),
                o.OnCompleted);
            });
        }
    }
}
