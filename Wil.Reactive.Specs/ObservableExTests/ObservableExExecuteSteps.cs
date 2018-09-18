using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExExecuteSteps
    {
        public ObservableExExecuteSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"an observable that publishes (.*) integers at (.*) intervals")]
        public void GivenAnObservableThatPublishesIntegersAtMillisecondIntervals(int count, Duration period)
        {
            IObservable<int> obs = Observable.Interval(period).Take(count).Select(x => (int)x);
            _scenario.Set(obs);
        }

        [Given(@"a method that records notifications")]
        public void GivenAMethodThatRecordsNotifications()
        {
            Action<string> notify = s => { _scenario.Update("notifications", n => n.Add(s), () => new List<string>()); };
            _scenario.Set(notify);
        }

        [Given(@"ExecuteRestartOnNew is chained to the observable using a normal function that errors when called with (.*)")]
        public void GivenExecuteRestartOnNewIsChainedToTheObservableUsingANormalFunctionThatErrorsWhenCalledWith(int target)
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var functionTimeout = _scenario.GetEx<Duration>("functionTimeout");
            var notify = _scenario.GetEx<Action<string>>();
            var sig = new CountdownEvent(1);

            obs = obs
                .ExecuteRestartOnNew(
                    x => GetResult(functionTimeout, x),
                    () => notify("Initialize"),
                    () => { notify("Finalize"); sig.Signal(); },
                    x => notify($"Starting {x}"),
                    x => notify($"Stopping {x}"));

            _scenario.Set(obs);
            _scenario.Set(sig);

            int GetResult(Duration timeout, int value)
            {
                if (value == target)
                    throw new Exception($"{target} received");

                Task.Delay(timeout.Value).Wait();
                return value;
            }
        }

        [Given(@"ExecuteRestartOnNew is chained to the observable using a normal function")]
        public void GivenExecuteRestartOnNewIsChainedToTheObservableUsingANormalFunction()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var functionTimeout = _scenario.GetEx<Duration>("functionTimeout");
            var notify = _scenario.GetEx<Action<string>>();
            var sig = new CountdownEvent(1);

            obs = obs
                .ExecuteRestartOnNew(
                    x => GetResult(functionTimeout, x),
                    () => notify("Initialize"),
                    () => { notify("Finalize"); sig.Signal(); },
                    x => notify($"Starting {x}"),
                    x => notify($"Stopping {x}"));

            _scenario.Set(obs);
            _scenario.Set(sig);

            int GetResult(Duration timeout, int value)
            {
                Task.Delay(timeout.Value).Wait();
                return value;
            }
        }

        [Given(@"ExecuteRestartOnNew is chained to the observable using a normal cancellable function")]
        public void GivenExecuteRestartOnNewIsChainedToTheObservableUsingANormalCancellableFunction()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var functionTimeout = _scenario.GetEx<Duration>("functionTimeout");
            var notify = _scenario.GetEx<Action<string>>();
            var sig = new CountdownEvent(1);

            obs = obs
                .ExecuteRestartOnNew(
                    (x, ct) => GetResult(functionTimeout, x, ct),
                    () => notify("Initialize"),
                    () => { notify("Finalize"); sig.Signal(); },
                    x => notify($"Starting {x}"),
                    x => notify($"Stopping {x}"));

            _scenario.Set(obs);
            _scenario.Set(sig);

            int GetResult(Duration timeout, int value, CancellationToken cancelToken)
            {
                Task.Delay(timeout.Value, cancelToken).Wait();
                return value;
            }
        }

        [Given(@"ExecuteRestartOnNew is chained to the observable using an async function")]
        public void GivenExecuteRestartOnNewIsChainedToTheObservableUsingAnAsyncFunction()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var functionTimeout = _scenario.GetEx<Duration>("functionTimeout");
            var notify = _scenario.GetEx<Action<string>>();
            var sig = new CountdownEvent(1);

            obs = obs
                .ExecuteRestartOnNew(
                    x => GetResultAsync(functionTimeout, x),
                    () => notify("Initialize"),
                    () => { notify("Finalize"); sig.Signal(); },
                    x => notify($"Starting {x}"),
                    x => notify($"Stopping {x}"));

            _scenario.Set(obs);
            _scenario.Set(sig);

            async Task<int> GetResultAsync(Duration timeout, int value)
            {
                await Task.Delay(timeout.Value);
                return value;
            }
        }

        [Given(@"ExecuteRestartOnNew is chained to the observable using an async cancellable function")]
        public void GivenExecuteRestartOnNewIsChainedToTheObservableUsingAnAsyncCancellableFunction()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var functionTimeout = _scenario.GetEx<Duration>("functionTimeout");
            var notify = _scenario.GetEx<Action<string>>();
            var sig = new CountdownEvent(1);

            obs = obs
                .ExecuteRestartOnNew(
                    (x, ct) => GetResultAsync(functionTimeout, x, ct),
                    () => notify("Initialize"),
                    () => { notify("Finalize"); sig.Signal(); },
                    x => notify($"Starting {x}"),
                    x => notify($"Stopping {x}"));

            _scenario.Set(obs);
            _scenario.Set(sig);

            async Task<int> GetResultAsync(Duration timeout, int value, CancellationToken cancelToken)
            {
                await Task.Delay(timeout.Value, cancelToken);
                return value;
            }
        }

        [When(@"a subscriber is subscribed")]
        public void WhenASubscriberIsSubscribed()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var sig = _scenario.GetEx<CountdownEvent>();
            sig.AddCount(1);

            IDisposable subscription = obs
                .Subscribe(
                    x => _scenario.Update(null, r => r.Add(x), () => new List<int>()),
                    ex =>
                    {
                        _scenario.Set(ex, "subscribeException");
                        sig.Signal();
                    },
                    () => sig.Signal());

            if (!sig.Wait(1000)) Assert.Fail("***** Timed out waiting for observable to complete. *****");

            subscription.Dispose();
        }

        private readonly ScenarioContext _scenario;
    }
}

