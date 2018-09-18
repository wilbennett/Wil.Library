/*
using Microsoft.Reactive.Testing;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Wil.Testing.Reactive
{
    public static class TaskExtensions
    {
        // Source: https://stackoverflow.com/questions/28183473/executing-tpl-code-in-a-reactive-pipeline-and-controlling-execution-via-test-sch
        public static IObservable<T> ToTestScheduledObseravble<T>(
            this Task<T> task,
            TestScheduler scheduler,
            TimeSpan duration,
            TimeSpan? timeout = null)
        {

            timeout = timeout ?? TimeSpan.FromSeconds(100);
            var subject = Subject.Synchronize(new AsyncSubject<T>(), scheduler);

            scheduler.Schedule(task, scheduler.Now.Add(duration), (s, t) =>
            {
                if (!task.Wait(timeout.Value))
                {
                    subject.OnError(new TimeoutException("Task duration too long"));
                }
                else
                {
                    switch (task.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            subject.OnNext(task.Result);
                            subject.OnCompleted();
                            break;

                        case TaskStatus.Faulted:
                            subject.OnError(task.Exception.InnerException);
                            break;

                        case TaskStatus.Canceled:
                            subject.OnError(new TaskCanceledException(task));
                            break;
                    }
                }

                return Disposable.Empty;
            });

            return subject.AsObservable();
        }
    }
}
//*/
