using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using TechTalk.SpecFlow;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExErrorsSteps
    {
        public ObservableExErrorsSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"an observable that publishes integers")]
        public void GivenAnObservableThatPublishesIntegers()
        {
            var subj = new Subject<int>();
            _scenario.Set(subj);
            _scenario.Set<IObservable<int>>(subj);
        }

        [Given(@"_a subscriber error handler")]
        public void GivenASubscriberErrorHandler()
        {
            Action<Exception> handler = ex => _scenario.Set(ex, "subscriberHandledException");
            _scenario.Set(handler, "subscriberHandler");
        }

        [Given(@"_a publisher error handler")]
        public void GivenAPublisherErrorHandler()
        {
            Action<Exception> handler = ex => _scenario.Set(ex, "publisherHandledException");
            _scenario.Set(handler, "publisherHandler");
        }

        [Given(@"SuppressSubscriberErrors is chained to the observable")]
        public void GivenSuppressSubscriberErrorsIsChainedToTheObservable()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var handler = _scenario.GetEx<Action<Exception>>("subscriberHandler");
            obs = obs.SuppressSubscriberErrors(handler);
            _scenario.Set(obs);
        }

        [Given(@"SuppressErrors is chained to the observable")]
        public void GivenSuppressErrorsIsChainedToTheObservable()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var subscriberHandler = _scenario.GetEx<Action<Exception>>("subscriberHandler");
            var publisherHandler = _scenario.GetEx<Action<Exception>>("publisherHandler");
            obs = obs.SuppressErrors(publisherHandler, subscriberHandler);
            _scenario.Set(obs);
        }

        [Given(@"_a normal subscriber")]
        public void GivenANormalSubscriber()
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var results = new List<int>();
            IDisposable subs = obs.Subscribe(results.Add);
            _scenario.Set(subs, "normalSubscriber");
            _scenario.Set(results, "normalResult");
        }

        [Given(@"a subscriber that throws an exception when (.*) is received")]
        public void GivenASubscriberThatThrowsAnExceptionWhenIsReceived(int target)
        {
            var obs = _scenario.GetEx<IObservable<int>>();
            var results = new List<int>();

            IDisposable subs = obs.Subscribe(x =>
            {
                if (x == target)
                    throw new Exception("Got target value");

                results.Add(x);
            });

            _scenario.Set(subs, "errorSubscriber");
            _scenario.Set(results, "errorResult");
        }

        [When(@"the observable publishes values (.*) to (.*)")]
        public void WhenTheObservablePublishesValuesTo(int start, int end)
        {
            var subj = _scenario.GetEx<Subject<int>>();

            try
            {
                for (int i = start; i <= end; i++)
                {
                    subj.OnNext(i);
                }

                subj.OnCompleted();
            }
            catch (Exception ex)
            {
                _scenario.Set(ex, "subscriberException");
            }

            if (_scenario.TryGetValue("normalSubscriber", out IDisposable subscriber))
                subscriber.Dispose();

            if (_scenario.TryGetValue("errorSubscriber", out subscriber))
                subscriber.Dispose();
        }

        [When(@"the observable publishes values 1, 2, 3, error")]
        public void WhenTheObservablePublishes123Error()
        {
            var subj = _scenario.GetEx<Subject<int>>();

            subj.OnNext(1);
            subj.OnNext(2);
            subj.OnNext(3);
            subj.OnError(new Exception("Publishing error"));

            if (_scenario.TryGetValue("normalSubscriber", out IDisposable subscriber))
                subscriber.Dispose();

            if (_scenario.TryGetValue("errorSubscriber", out subscriber))
                subscriber.Dispose();
        }

        private readonly ScenarioContext _scenario;
    }
}

