using Microsoft.Reactive.Testing;
using System;
using System.Linq;
using System.Reactive.Linq;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExTimerSteps
    {
        public ObservableExTimerSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"a RandomTimer observable that publishes (\d+) values is created")]
        public void GivenARandomTimerObservableThatPublishesValuesIsCreated(int count)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var dueTime = _scenario.GetEx<Duration>("dueTime");
            var minPeriod = _scenario.GetEx<Duration>("minPeriod");
            var maxPeriod = _scenario.GetEx<Duration>("maxPeriod");

            IObservable<int> obs = ObservableEx
                .RandomTimer(dueTime, minPeriod, maxPeriod, scheduler)
                .Take(count)
                .Select(x => (int)x);

            _scenario.Set(obs);
        }

        [Given(@"a ResetTimer observable is created that uses (.*) as the reset source")]
        public void GivenAResetTimerObservableIsCreatedThatUsesAsTheResetSource(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var resetSource = _scenario.GetEx<IObservable<int>>(streamKey);
            var dueTime = _scenario.GetEx<Duration>("dueTime");
            var period = _scenario.GetEx<Duration>("period");

            IObservable<int> obs = ObservableEx
                .ResetTimer(dueTime, period, resetSource, scheduler).Select(x => (int)x);

            _scenario.Set(obs);
        }

        [Given(@"Timeout is chained to observable (.*)")]
        public void GivenTimeoutIsChainedToObservable(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var stream = _scenario.GetEx<IObservable<int>>(streamKey);
            var period = _scenario.GetEx<Duration>("period");
            var timeoutValue = _scenario.GetEx<int>("timeoutValue");

            IObservable<int> obs = stream.Timeout(period, timeoutValue, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"TimeoutScan is chained to observable (.*)")]
        public void GivenTimeoutScanIsChainedToObservable(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var stream = _scenario.GetEx<IObservable<int>>(streamKey);
            var period = _scenario.GetEx<Duration>("period");
            var timeoutValue = _scenario.GetEx<int>("timeoutValue");

            IObservable<int> obs = stream.TimeoutScan(period, timeoutValue, scheduler);
            _scenario.Set(obs);
        }

        private readonly ScenarioContext _scenario;
    }
}

