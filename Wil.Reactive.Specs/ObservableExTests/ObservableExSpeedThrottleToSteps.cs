using Microsoft.Reactive.Testing;
using System;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExSpeedThrottleToSteps
    {
        public ObservableExSpeedThrottleToSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"ThrottleTo is chained to observable (.*)")]
        public void GivenThrottleToIsChainedToObservableStream(string streamKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var stream = _scenario.GetEx<IObservable<int>>(streamKey);
            var count = _scenario.GetEx<int>("count");
            var period = _scenario.GetEx<Duration>("period");

            var rate = new Rate(count, period);

            IObservable<int> obs = stream.ThrottleTo(rate, scheduler);
            _scenario.Set(obs);
        }

        private readonly ScenarioContext _scenario;
    }
}

