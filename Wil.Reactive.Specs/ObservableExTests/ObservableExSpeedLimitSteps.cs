using Microsoft.Reactive.Testing;
using System;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExSpeedLimitSteps
    {
        public ObservableExSpeedLimitSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }


        [Given(@"LimitTo is chained to observable (.*)")]
        public void GivenLimitToIsChainedToTheObservable(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var stream = _scenario.GetEx<IObservable<int>>(streamKey);
            var count = _scenario.GetEx<int>("count");
            var period = _scenario.GetEx<Duration>("period");

            var rate = new Rate(count, period);

            IObservable<int> obs = stream.LimitTo(rate, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"LimitTo 1 per period is chained to observable (.*)")]
        public void GivenLimitTo1PerPeriodIsChainedToTheObservable(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var stream = _scenario.GetEx<IObservable<int>>(streamKey);
            var period = _scenario.GetEx<Duration>("period");

            IObservable<int> obs = stream.LimitTo(period, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"LimitTo range is chained to observable (.*)")]
        public void GivenLimitToRangeIsChainedToTheObservable(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var stream = _scenario.GetEx<IObservable<int>>(streamKey);
            var minPeriod = _scenario.GetEx<Duration>("minPeriod");
            var maxPeriod = _scenario.GetEx<Duration>("maxPeriod");

            IObservable<int> obs = stream.LimitTo(minPeriod, maxPeriod, scheduler);
            _scenario.Set(obs);
        }

        private readonly ScenarioContext _scenario;
    }
}

