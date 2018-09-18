using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using Wil.Reactive;

namespace Wil.Reactivve.Specs
{
    [Binding]
    public class StopwatchClockFeatureSteps
    {
        public StopwatchClockFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"an instance of the StopwatchClock class")]
        public void GivenAnInstanceOfTheStopwatchClockClass()
        {
            _scenario.Set(new StopwatchClock());
        }

        [When(@"the property values are retrieved")]
        public void WhenThePropertyValuesAreRetrieved()
        {
            var clock = _scenario.Get<StopwatchClock>();
            _scenario.Set(DateTime.Now, "DateTimeNow");
            _scenario.Set(clock.Now, "ClockNow");
            _scenario.Set(clock.Ticks, "Ticks");
            _scenario.Set(clock.Elapsed, "Elapsed");
        }

        [Then(@"the Now value should be within one second of DateTime\.Now")]
        public void ThenTheNowValueShouldBeWithinOneSecondOfDateTimeNow()
        {
            var dateTimeNow = _scenario.Get<DateTime>("DateTimeNow");
            var clockNow = _scenario.Get<DateTime>("ClockNow");
            var actual = Math.Abs((int)(dateTimeNow - clockNow).TotalSeconds);

            Assert.IsTrue(actual <= 1);
        }

        [Then(@"the Elapsed value should be within one second of the result of the CalculateElapsed method")]
        public void TheElapseValueShouldBeWithinOneSecondOfTheResultOfTheCalculateElapsedMethod()
        {
            var clock = _scenario.Get<StopwatchClock>();
            var ticks = _scenario.Get<long>("Ticks");
            var elapsed = _scenario.Get<TimeSpan>("Elapsed");
            var actual = Math.Abs((int)(elapsed - clock.CalculateElapsed(ticks)).TotalSeconds);

            Assert.IsTrue(actual <= 1);
        }

        [Then(@"the Now value should be within one second of the result of the ToDateTime method")]
        public void ThenTheNowValueShouldBeWithinOneSecondOfTheResultOfTheToDateTimeMethod()
        {
            var clock = _scenario.Get<StopwatchClock>();
            var clockNow = _scenario.Get<DateTime>("ClockNow");
            var ticks = _scenario.Get<long>("Ticks");
            var actual = Math.Abs((int)(clockNow - clock.ToDateTime(ticks)).TotalSeconds);

            Assert.IsTrue(actual <= 1);
        }

        private readonly ScenarioContext _scenario;
    }
}

