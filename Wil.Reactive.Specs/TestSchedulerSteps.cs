using Microsoft.Reactive.Testing;
using System;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class TestSchedulerSteps
    {
        public TestSchedulerSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"_a test scheduler")]
        public void GivenATestScheduler() => _scenario.Set(new TestScheduler());

        [Given(@"(\w+) (?:i|a)s a TestScheduler")]
        public void GivenIsATestScheduler(string key) => _scenario.Set(new TestScheduler(), key);

        [Given(@"time advances by ([\d\.]+ \w+)")]
        [When(@"time advances by ([\d\.]+ \w+)")]
        public void WhenTimeAdvancesBy(Duration period)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            AdvanceTimeBy(period, scheduler);
        }

        //[Given(@"time advances by (\w+)")]
        //[When(@"time advances by (\w+)")]
        //public void WhenTimeAdvancesBy(string periodKey)
        //{
        //    var scheduler = _scenario.GetEx<TestScheduler>();
        //    var period = _scenario.GetEx<Duration>(periodKey);
        //    AdvanceTimeBy(period, scheduler);
        //}

        [Given(@"time advances to ((?:[\d\.]+) \w+)")]
        [When(@"time advances to ((?:[\d\.]+) \w+)")]
        public void WhenTimeAdvancesTo(Duration period)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            AdvanceTimeTo(period, scheduler);
        }

        //[Given(@"time advances to (\d+), (\d+), (\d+)")]
        //[When(@"time advances to (\d+), (\d+), (\d+)")]
        //public void WhenTimeAdvancesTo(int year, int month, int day)
        //{
        //    var scheduler = _scenario.GetEx<TestScheduler>();
        //    AdvanceTimeTo(new DateTime(year, month, day).Ticks, scheduler);
        //}

        [Given(@"time advances to date time offset (\w+)")]
        [When(@"time advances to date time offset (\w+)")]
        public void WhenTimeAdvancesToDateTimeOffset(string key)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var target = _scenario.GetEx<DateTimeOffset>(key);
            AdvanceTimeTo(target.Ticks, scheduler);
        }

        //[Given(@"time advances to date time (\w+)")]
        //[When(@"time advances to date time (\w+)")]
        //public void WhenTimeAdvancesToDateTime(string key)
        //{
        //    var scheduler = _scenario.GetEx<TestScheduler>();
        //    var target = _scenario.GetEx<DateTime>(key);
        //    AdvanceTimeTo(target.Ticks, scheduler);
        //}

        [Given(@"the scheduler Now property is retrieved as (\w+)")]
        [When(@"the scheduler Now property is retrieved as (\w+)")]
        public void GivenTheSchedulerNowPropertyIsRetrievedAs(string resultKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();

            _scenario.Set(scheduler.Now, resultKey);
        }

        [Given(@"the scheduler Now property is retrieved as UTC date time (\w+)")]
        [When(@"the scheduler Now property is retrieved as UTC date time (\w+)")]
        public void GivenTheSchedulerNowPropertyIsRetrievedAsUtcDateTime(string resultKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();

            _scenario.Set(scheduler.Now.UtcDateTime, resultKey);
        }

        [Given(@"the scheduler Now property is retrieved as date time (\w+)")]
        [When(@"the scheduler Now property is retrieved as date time (\w+)")]
        public void GivenTheSchedulerNowPropertyIsRetrievedAsDateTime(string resultKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();

            _scenario.Set(scheduler.Now.LocalDateTime, resultKey);
        }

        [Given(@"the elapsed ticks of the scheduler from (\w+) is retrieved as (\w+)")]
        [When(@"the elapsed ticks of the scheduler from (\w+) is retrieved as (\w+)")]
        public void ThenTheElapsedTicksOfTheSchedulerFromIsRetrievedAs(string startTimeKey, string resultKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var startTime = _scenario.Get<DateTimeOffset>(startTimeKey);

            long result = (scheduler.Now.ToUniversalTime() - startTime).Ticks;
            _scenario.Set(result, resultKey);
        }

        [Given(@"the elapsed time of the scheduler from (\w+) is retrieved as (\w+)")]
        [When(@"the elapsed time of the scheduler from (\w+) is retrieved as (\w+)")]
        public void ThenTheElapsedTimeOfTheSchedulerFromIsRetrievedAs(string startTimeKey, string resultKey)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var startTime = _scenario.Get<DateTimeOffset>(startTimeKey);

            TimeSpan result = scheduler.Now.UtcDateTime - startTime.UtcDateTime;
            Console.WriteLine($"***** {scheduler.Now.UtcDateTime} - {startTime.UtcDateTime} = {result}");
            _scenario.Set(result, resultKey);
        }

        //[Then(@"the result should be equal to the elapsed ticks of the scheduler from (.*)")]
        //public void ThenTheResultShouldBeEqualToTheElapsedTicksOfTheSchedulerFrom(string startTimeKey)
        //{
        //    var scheduler = _scenario.GetEx<TestScheduler>();
        //    var startTime = _scenario.Get<DateTimeOffset>(startTimeKey);
        //    var actual = _scenario.Get<long>();

        //    long expected = (startTime - scheduler.Now.ToLocalTime()).Ticks;
        //    Assert.AreEqual(expected, actual);
        //}

        //[Then(@"the result should be equal to the elapsed time of the scheduler from (.*)")]
        //public void ThenTheResultShouldBeEqualToTheElapsedTimeOfTheSchedulerFrom(string startTimeKey)
        //{
        //    var scheduler = _scenario.GetEx<TestScheduler>();
        //    var startTime = _scenario.Get<DateTimeOffset>(startTimeKey);
        //    var actual = _scenario.Get<TimeSpan>();

        //    TimeSpan expected = startTime - scheduler.Now.ToLocalTime();
        //    Assert.AreEqual(expected, actual);
        //}

        private readonly ScenarioContext _scenario;

        private static void AdvanceTimeBy(Duration period, TestScheduler scheduler)
        {
            scheduler.AdvanceBy(period.Value.Ticks);
            Console.WriteLine($"Advaned by {period.Value.Ticks} ticks to {scheduler.Clock} ({scheduler.Now.TimeOfDay}).");
        }

        private static void AdvanceTimeTo(Duration period, TestScheduler scheduler)
        {
            scheduler.AdvanceTo(period.Value.Ticks);
            Console.WriteLine($"Advaned to {scheduler.Clock} ({scheduler.Now.TimeOfDay}).");
        }
    }
}

