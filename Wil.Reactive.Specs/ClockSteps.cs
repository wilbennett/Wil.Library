using Microsoft.Reactive.Testing;
using System;
using System.Diagnostics.CodeAnalysis;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ClockSteps
    {
        public ClockSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"_a Clock instance")]
        public void GivenAClockInstance()
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            IClock clock = new Clock(scheduler);

            _scenario.Set(clock);
        }
        
        [When(@"the NowOffset property is accessed")]
        public void WhenTheNowOffsetPropertyIsAccessed()
        {
            var clock = _scenario.GetEx<IClock>();
            _scenario.Set(clock.NowOffset, nameof(clock.NowOffset));
        }

        [When(@"the UtcNow property is accessed")]
        public void WhenTheUtcNowPropertyIsAccessed()
        {
            var clock = _scenario.GetEx<IClock>();
            _scenario.Set(clock.UtcNow, nameof(clock.UtcNow));
        }

        [When(@"the Now property is accessed")]
        public void WhenTheNowPropertyIsAccessed()
        {
            var clock = _scenario.GetEx<IClock>();
            _scenario.Set(clock.Now, nameof(clock.Now));
        }

        [When(@"the Elapsed property is accessed")]
        public void WhenTheElapsedPropertyIsAccessed()
        {
            var clock = _scenario.GetEx<IClock>();
            _scenario.Set(clock.Elapsed, nameof(clock.Elapsed));
        }

        [When(@"the DateTimeTicks property is accessed")]
        public void WhenTheDateTimeTicksPropertyIsAccessed()
        {
            var clock = _scenario.GetEx<IClock>();
            _scenario.Set(clock.DateTimeTicks, nameof(clock.DateTimeTicks));
        }

        [When(@"the Ticks property is accessed")]
        public void WhenTheTicksPropertyIsAccessed()
        {
            var clock = _scenario.GetEx<IClock>();
            _scenario.Set(clock.Ticks, nameof(clock.Ticks));
        }

        [When(@"the ToDateTimeOffset method is called")]
        public void WhenTheToDateTimeOffsetMethodIsCalled()
        {
            var clock = _scenario.GetEx<IClock>();
            var ticks = _scenario.GetEx<long>(nameof(clock.Ticks));

            DateTimeOffset result = clock.ToDateTimeOffset(ticks);
            _scenario.Set(result);
        }

        private readonly ScenarioContext _scenario;
    }
}

