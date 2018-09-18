using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using TechTalk.SpecFlow;
using Wil.Testing.SpecFlow;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class ObservableExBooleanSteps
    {
        public ObservableExBooleanSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given(@"Inverse is chained to the observable")]
        public void GivenInverseIsChainedToTheObservable()
        {
            var subj0 = _scenario.GetEx<Subject<bool>>("subj0");
            var obs = subj0.Inverse();
            _scenario.Set(obs);
        }

        [Given(@"ReferenceCounted is chained to the observable")]
        public void GivenReferenceCountedIsChainedToTheObservable()
        {
            var subj0 = _scenario.GetEx<Subject<bool>>("subj0");
            var obs = subj0.ReferenceCounted();
            _scenario.Set(obs);
        }

        [Given(@"(.*) observables that publish boolean values")]
        public void GivenObservablesThatPublishBooleanValues(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var subj = new Subject<bool>();
                _scenario.Set(subj, $"subj{i}");
            }
        }

        [Given(@"the two observables are combined with ""(.*)""")]
        public void GivenTheTwoObservablesAreCombinedWith(string operation)
        {
            var subj0 = _scenario.GetEx<Subject<bool>>("subj0");
            var subj1 = _scenario.GetEx<Subject<bool>>("subj1");

            IObservable<bool> obs = null;

            switch (operation)
            {
                case "And":
                    obs = subj0.And(subj1);
                    break;

                case "Or":
                    obs = subj0.Or(subj1);
                    break;

                case "Xor":
                    obs = subj0.Xor(subj1);
                    break;

                case "AndNot":
                    obs = subj0.AndNot(subj1);
                    break;

                case "OrNot":
                    obs = subj0.OrNot(subj1);
                    break;
            }

            _scenario.Set(obs);
        }

        [Given(@"the observables are combined with ""(.*)""")]
        public void GivenTheObservablesAreCombinedWith(string operation)
        {
            var subj0 = _scenario.GetEx<Subject<bool>>("subj0");
            var others = new List<Subject<bool>>();
            int index = 1;

            while (_scenario.TryGetValue($"subj{index}", out Subject<bool> subj))
            {
                others.Add(subj);
                index++;
            }

            IObservable<bool> obs = null;

            switch (operation)
            {
                case "And":
                    obs = subj0.And(others.ToArray());
                    break;

                case "Or":
                    obs = subj0.Or(others.ToArray());
                    break;

                case "Xor":
                    obs = subj0.Xor(others.ToArray());
                    break;

                case "AndNot":
                    obs = subj0.AndNot(others.ToArray());
                    break;

                case "OrNot":
                    obs = subj0.OrNot(others.ToArray());
                    break;
            }

            _scenario.Set(obs);
        }

        [Given(@"_a boolean subscriber")]
        public void GivenABooleanSubscriber()
        {
            var obs = _scenario.GetEx<IObservable<bool>>();
            var results = new List<bool>();
            IDisposable subscription = obs.Subscribe(results.Add, ex => _scenario.Set(ex, "subscriberException"));
            _scenario.Set(results);
            _scenario.Set(subscription, "subscription");
        }

        [When(@"observable (.*) publishes (.*)")]
        public void WhenObservablePublishes(int index, bool value)
        {
            var subj = _scenario.GetEx<Subject<bool>>($"subj{index}");
            subj.OnNext(value);
        }

        [When(@"observable (.*) is completed")]
        public void WhenObservableIsCompleted(int index)
        {
            var subj = _scenario.GetEx<Subject<bool>>($"subj{index}");
            subj.OnCompleted();
        }

        private readonly ScenarioContext _scenario;
    }
}

