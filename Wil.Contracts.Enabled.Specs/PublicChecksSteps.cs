using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Wil.Contracts.Extensions;

namespace Wil.Contracts.specs
{
    [Binding]
    public class PublicChecksFeatureSteps
    {
        public PublicChecksFeatureSteps(ScenarioContext scenarioContext)
            => _scenario = scenarioContext;

        public void TrueMessageException(string value)
            => Expect.True<ArgumentException>(value != null, _scenario.Get<string>("message"));

        public void TrueException(string value) => Expect.True<ArgumentException>(value != null);

        public void TrueMessage(string value)
            => Expect.True(value != null, _scenario.Get<string>("message"));

        public void True(string value)
        {
            Expect.True(value == null); // HACK: Test the passing condition in Expect.True.
            Expect.True(value != null);
        }

        public void NotNullMessageException(string value)
            => value.ExpectNotNull<ArgumentException>(_scenario.Get<string>("message"));

        public void NotNullException(string value) => value.ExpectNotNull<ArgumentException>();
        public void NotNullMessage(string value) => value.ExpectNotNull(_scenario.Get<string>("message"));
        public void NotNull(string value) => value.ExpectNotNull();

        public void NotNullAssertMessage(string value)
            => value.AssertNotNull(_scenario.Get<string>("message"));

        public void NotNullAssert(string value) => value.AssertNotNull();

        public void AssertMessage(string value)
            => Expect.Assert(value != null, _scenario.Get<string>("message"));

        public void DoAssert(string value) => Expect.Assert(value != null);

        [Given(@"a public method with a true check, custom message and ArgumentException")]
        public void GivenAPublicMethodWithATrueCheckCustomMessageAndArgumentException()
            => _scenario.Set<Action>(() => TrueMessageException(null));

        [Given(@"a public method with a true check using ArgumentException")]
        public void GivenAPublicMethodWithATrueCheckUsingArgumentException()
            => _scenario.Set<Action>(() => TrueException(null));

        [Given(@"a public method with a true check and custom message")]
        public void GivenAPublicMethodWithATrueCheckAndCustomMessage()
            => _scenario.Set<Action>(() => TrueMessage(null));

        [Given(@"a public method with a true check")]
        public void GivenAPublicMethodWithATrueCheck() => _scenario.Set<Action>(() => True(null));

        [Given(@"a public method with a not null check, custom message and ArgumentException")]
        public void GivenAPublicMethodWithANotNullCheckCustomMessageAndArgumentException()
            => _scenario.Set<Action>(() => NotNullMessageException(null));

        [Given(@"a public method with a not null check using ArgumentException")]
        public void GivenAPublicMethodWithANotNullCheckUsingArgumentException()
            => _scenario.Set<Action>(() => NotNullException(null));

        [Given(@"a public method with a not null check and custom message")]
        public void GivenAPublicMethodWithANotNullCheckAndCustomMessage()
            => _scenario.Set<Action>(() => NotNullMessage(null));

        [Given(@"a public method with a not null check")]
        public void GivenAPublicMethodWithANotNullCheck() => _scenario.Set<Action>(() => NotNull(null));

        [Given(@"a public method with a not null assertion check and custom message")]
        public void GivenAPublicMethodWithANotNullAssertionCheckAndCustomMessage()
        {
            Action method = () =>
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new TestTraceListener(_scenario));
                NotNullAssertMessage(null);
                Trace.Listeners.Clear();
            };

            _scenario.Set(method);
        }

        [Given(@"a public method with a not null assertion check")]
        public void GivenAPublicMethodWithANotNullAssertionCheck()
        {
            Action method = () =>
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new TestTraceListener(_scenario));
                NotNullAssert(null);
                Trace.Listeners.Clear();
            };

            _scenario.Set(method);
        }

        [Given(@"a public method with an assertion check and custom message")]
        public void GivenAPublicMethodWithAnAssertionCheckAndCustomMessage()
        {
            Action method = () =>
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new TestTraceListener(_scenario));
                AssertMessage(null);
                Trace.Listeners.Clear();
            };

            _scenario.Set(method);
        }

        [Given(@"a public method with an assertion check")]
        public void GivenAPublicMethodWithAnAssertionCheck()
        {
            Action method = () =>
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new TestTraceListener(_scenario));
                DoAssert(null);
                Trace.Listeners.Clear();
            };

            _scenario.Set(method);
        }

        private readonly ScenarioContext _scenario;
    }
}

