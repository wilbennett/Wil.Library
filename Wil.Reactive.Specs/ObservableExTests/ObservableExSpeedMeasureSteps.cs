using Microsoft.Reactive.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Reactive.Interfaces;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExSpeedMeasureSteps : ReactiveTest
    {
        public ObservableExSpeedMeasureSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"_(\w+) is concatenated to (\w+)")]
        public void GivenIsConcatenatedTo(string obs2Key, string obs1Key)
        {
            var sc = _scenario.GetEx<TestScheduler>();
            var obs1 = _scenario.GetEx<IObservable<int>>(obs1Key);
            var obs2 = _scenario.GetEx<IObservable<int>>(obs2Key);

            IObservable<int> obs = obs1.Concat(obs2);
            _scenario.Set(obs);
        }

        [Given(@"Measure is chained to the observable")]
        public void GivenMeasureIsChainedToTheObservable()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var measurePeriod = _scenario.GetEx<Duration>("measurePeriod");
            var stream = _scenario.Get<IObservable<int>>();

            IObservable<Rate> obs = stream.Measure(measurePeriod, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"MeasureScan is chained to the observable")]
        public void GivenMeasureScanIsChainedToTheObservable()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var measurePeriod = _scenario.GetEx<Duration>("measurePeriod");
            var stream = _scenario.Get<IObservable<int>>();

            IObservable<RateEvent<int>> obs = stream.MeasureScan(measurePeriod, scheduler);
            _scenario.Set(obs);
        }

        [When(@"a rate subscriber is subscribed")]
        public void WhenAnRateSubscriberIsSubscribed()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var obs = _scenario.Get<IObservable<Rate>>();
            Rate.CountFormatString = "F0";

            IDisposable subscription = obs.Subscribe(
                x =>
                {
                    _scenario.Update(null, r => r.Add($"{x}"), () => new List<string>());
                }, () => Console.WriteLine($"OBS COMPLETE {scheduler.Now.TimeOfDay}: {string.Join(", ", _scenario.GetEx<List<string>>())}"));

            _scenario.Set(subscription, "subscription");
        }

        [When(@"an integer rate event subscriber is subscribed")]
        public void WhenAnIntegerRateEventSubscriberIsSubscribed()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var obs = _scenario.Get<IObservable<RateEvent<int>>>();

            IDisposable subscription = obs.Subscribe(
                x =>
                {
                    _scenario.Update(null, r => r.Add($"{x.Value}@{x.Count:F0}"), () => new List<string>());
                }, () => Console.WriteLine($"OBS COMPLETE {scheduler.Now.TimeOfDay}: {string.Join(", ", _scenario.GetEx<List<string>>())}"));

            _scenario.Set(subscription, "subscription");
        }

        private readonly ScenarioContext _scenario;
    }
}

