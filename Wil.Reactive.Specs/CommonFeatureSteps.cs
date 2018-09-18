using Microsoft.Reactive.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class CommonFeatureSteps : ReactiveTest
    {
        public CommonFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [BeforeFeature]
        private static void Hacks()
        {
            // HACK: Force loading of Wil.Reactive assembly into the application domain.
            Type dummy = typeof(Speedometer);
        }

        [Given(@"_(\w+) is ((?:[\d\.]+) (?:milliseconds?))")]
        public void GivenIsMilliseconds(string name, Duration period) => _scenario.Set(period, name);

        [Given(@"_(\w+) is ((?:[\d\.]+) (?:seconds?))")]
        public void GivenIsSeconds(string name, Duration period) => _scenario.Set(period, name);

        [Given(@"an observable (\w+) that publishes (\d+) integers at a rate of (\d+) every (\d+ \w+) starting at (\d+ \w+)")]
        public void GivenAnObservableThatPublishesIntegersAtARateOf1EveryStartingAt(string name, int count, int periodCount, Duration period, Duration start)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            Duration currentTime = start;
            int currentCount = count;
            int index = 0;
            var messages = new Recorded<Notification<int>>[count + 1];

            while (currentCount > 0)
            {
                int countToAdd = Math.Min(periodCount, currentCount);

                for (int i = 0; i < countToAdd; i++)
                {
                    messages[index] = OnNext(currentTime, index + 1);
                    index++;
                }

                currentTime = currentTime + period;
                currentCount -= countToAdd;
            }

            messages[count] = OnCompleted<int>(currentTime - period);
            IObservable<int> obs = scheduler.CreateColdObservable(messages);

            //Array.ForEach(messages, m => Console.WriteLine(m));

            _scenario.Set(obs, name);
        }

        [Given(@"_an integer subscriber is subscribed")]
        [When(@"_an integer subscriber is subscribed")]
        public void WhenAnIntegerSubscriberIsSubscribed()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var obs = _scenario.Get<IObservable<int>>();

            IDisposable subscription = obs.Subscribe(
                x =>
                {
                    _scenario.Update("resultsCount", r => r + 1, 0);
                    _scenario.Update(null, r => r.Add(x), () => new List<int>());
                }
                , () => Console.WriteLine($"OBS COMPLETE {scheduler.Now.TimeOfDay}: {string.Join(", ", _scenario.GetEx<List<int>>())}")
                );

            _scenario.Set(subscription, "subscription");
        }

        [Given(@"an integer subscriber with time is subscribed")]
        [When(@"an integer subscriber with time is subscribed")]
        public void WhenAnIntegerSubscriberWithTimeIsSubscribed()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var obs = _scenario.Get<IObservable<int>>();

            IDisposable subscription = obs.Subscribe(
                x =>
                {
                    _scenario.Update("resultsCount", r => r + 1, 0);
                    _scenario.Update(null, r => r.Add($"{x}@{scheduler.Now.TimeOfDay}"), () => new List<string>());
                }
                , () => Console.WriteLine($"OBS COMPLETE {scheduler.Now.TimeOfDay}: {string.Join(", ", _scenario.GetEx<List<string>>())}")
                );

            _scenario.Set(subscription, "subscription");
        }

        [Given(@"an integer subscriber with interval is subscribed")]
        [When(@"an integer subscriber with interval is subscribed")]
        public void WhenAnIntegerSubscriberWithIntervalIsSubscribed()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var obs = _scenario.Get<IObservable<int>>();

            IDisposable subscription = obs
                .TimeInterval(scheduler)
                .Subscribe(
                    x =>
                    {
                        _scenario.Update("resultsCount", r => r + 1, 0);
                        _scenario.Update(null, r => r.Add(x), () => new List<TimeInterval<int>>());
                    }
                    , () => Console.WriteLine($"OBS COMPLETE {scheduler.Now.TimeOfDay}: {string.Join(", ", _scenario.GetEx<List<TimeInterval<int>>>())}")
                );

            _scenario.Set(subscription, "subscription");
        }

        [Given(@"_an integer subscriber is subscribed that errors on (\d+)")]
        [When(@"_an integer subscriber is subscribed that errors on (\d+)")]
        public void WhenAnIntegerSubscriberIsSubscribedThatErrorsOn(int target)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var obs = _scenario.Get<IObservable<int>>();

            IDisposable subscription = obs.Subscribe(
                x =>
                {
                    if (x == target)
                        throw new Exception($"Target {target} received");

                    _scenario.Update("resultsCount", r => r + 1, 0);
                    _scenario.Update(null, r => r.Add(x), () => new List<int>());
                }
                //, () => Console.WriteLine($"OBS COMPLETE {scheduler.Now.TimeOfDay}: {string.Join(", ", _scenario.GetEx<List<int>>())}")
                );

            _scenario.Set(subscription, "subscription");
        }

        [Then(@"the integer time intervals should not all be the same")]
        public void ThenTheIntegerTimeIntervalsShouldNotAllBeTheSame()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var results = _scenario.Get<List<TimeInterval<int>>>();
            var first = results[0];

            Assert.IsTrue(results.Any(ti => ti.Interval != first.Interval));
        }

        [Then(@"the integer time intervals should all be between (.*) and (.*)")]
        public void ThenTheIntegerTimeIntervalsShouldAllBeBetween(string lowKey, string highKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var results = _scenario.Get<List<TimeInterval<int>>>();
            var low = _scenario.GetEx<Duration>(lowKey);
            var high = _scenario.GetEx<Duration>(highKey);

            Assert.IsTrue(results.All(ti => ti.Interval >= low.Value && ti.Interval <= high.Value));
        }

        [Then(@"the integer time intervals except the first should all be between (.*) and (.*)")]
        public void ThenTheIntegerTimeIntervalsExceptTheFirstShouldAllBeBetween(string lowKey, string highKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var results = _scenario.Get<List<TimeInterval<int>>>();
            var low = _scenario.GetEx<Duration>(lowKey);
            var high = _scenario.GetEx<Duration>(highKey);

            Assert.IsTrue(results.Skip(1).All(ti => ti.Interval >= low.Value && ti.Interval <= high.Value));
        }

        private readonly ScenarioContext _scenario;
    }
}

