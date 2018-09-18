using Microsoft.Reactive.Testing;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;
using Wil.Reactive.Interfaces;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExStaleSteps
    {
        public ObservableExStaleSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"an observable that publishes integers ""(.*)"" at (.*) intervals")]
        public void GivenAnObservableThatPublishesIntegersAtIntervals(List<int> values, Duration period)
        {
            var scheduler = _scenario.GetEx<TestScheduler>();
            var messages = new Recorded<Notification<int>>[values.Count + 1];
            TimeSpan currentTime = TimeSpan.Zero;

            for (int i = 0; i < values.Count; i++)
            {
                currentTime = currentTime.Add(period);
                messages[i] = new Recorded<Notification<int>>(currentTime.Ticks, Notification.CreateOnNext(values[i]));
            }

            messages[values.Count] = new Recorded<Notification<int>>(currentTime.Ticks, Notification.CreateOnCompleted<int>());

            ITestableObservable<int> obs = scheduler.CreateColdObservable(messages);
            _scenario.Set(obs);
        }

        [Given(@"a function that groups integers into evens and odds")]
        public void GivenAFunctionThatGroupsIntegersIntoEvensAndOdds()
        {
            Func<int, string> keySelector = x => x % 2 == 0 ? "even" : "odd";
            _scenario.Set(keySelector);
        }

        [Given(@"DetectStale is chained to the observable")]
        public void GivenDetectStaleIsChainedToTheObservable()
        {
            var source = _scenario.GetEx<ITestableObservable<int>>();
            var period = _scenario.GetEx<Duration>("stalePeriod");
            var scheduler = _scenario.GetEx<TestScheduler>();

            IObservable<Stale<int>> obs = source.DetectStale(period, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"DetectStaleScan is chained to the observable")]
        public void GivenDetectStaleScanIsChainedToTheObservable()
        {
            var source = _scenario.GetEx<ITestableObservable<int>>();
            var period = _scenario.GetEx<Duration>("stalePeriod");
            var scheduler = _scenario.GetEx<TestScheduler>();

            IObservable<Stale<int>> obs = source.DetectStaleScan(period, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"DetectStaleGroup is chained to the observable")]
        public void GivenDetectStaleGroupIsChainedToTheObservable()
        {
            var source = _scenario.GetEx<ITestableObservable<int>>();
            var period = _scenario.GetEx<Duration>("stalePeriod");
            var keySelector = _scenario.GetEx<Func<int, string>>();
            var scheduler = _scenario.GetEx<TestScheduler>();

            IObservable<StaleGroup<string, int>> obs = source.DetectStaleGroup(keySelector, period, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"DetectStaleGroupScan is chained to the observable")]
        public void GivenDetectStaleGroupScanIsChainedToTheObservable()
        {
            var source = _scenario.GetEx<ITestableObservable<int>>();
            var period = _scenario.GetEx<Duration>("stalePeriod");
            var keySelector = _scenario.GetEx<Func<int, string>>();
            var scheduler = _scenario.GetEx<TestScheduler>();

            IObservable<StaleGroup<string, int>> obs = source.DetectStaleGroupScan(keySelector, period, scheduler);
            _scenario.Set(obs);
        }

        [Given(@"_a stale integer subscriber")]
        public void GivenAStaleIntegerSubscriber()
        {
            var obs = _scenario.GetEx<IObservable<Stale<int>>>();
            var results = new List<int>();

            var subscription = obs
                .Subscribe(x =>
                {
                    Console.WriteLine(x);

                    if (x.IsFresh)
                        results.Add(x.Value);
                    else
                        _scenario.Update<int>("staleCount", v => v + 1);
                });

            _scenario.Set(0, "staleCount");
            _scenario.Set(results);
            _scenario.Set(subscription, "subscription");
        }

        [Given(@"_a stale group integer subscriber")]
        public void GivenAStaleGroupIntegerSubscriber()
        {
            var obs = _scenario.GetEx<IObservable<StaleGroup<string, int>>>();

            var subscription = obs
                .Subscribe(x =>
                {
                    Console.WriteLine(x);

                    if (x.IsFresh)
                        _scenario.Update($"{x.Key}Results", results => results.Add(x.Value), () => new List<int>());
                    else
                        _scenario.Update($"{x.Key}StaleCount", v => v + 1, 0);
                });

            _scenario.Set(subscription, "subscription");
        }

        private readonly ScenarioContext _scenario;
    }
}

