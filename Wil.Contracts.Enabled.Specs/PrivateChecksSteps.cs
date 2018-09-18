using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Wil.Contracts.Extensions;

namespace Wil.Contracts.specs
{
    [Binding]
    public class PrivateChecksFeatureSteps
    {
        public PrivateChecksFeatureSteps(ScenarioContext scenarioContext)
            => _scenario = scenarioContext;

        public void TrueMessageException(string value)
            => ExpectPrivate.True<ArgumentException>(value != null, _scenario.Get<string>("message"));

        public void TrueException(string value) => ExpectPrivate.True<ArgumentException>(value != null);

        public void TrueMessage(string value)
            => ExpectPrivate.True(value != null, _scenario.Get<string>("message"));

        public void True(string value)
        {
            ExpectPrivate.True(value == null); // HACK: Test the passing condition in ExpectPrivate.True.
            ExpectPrivate.True(value != null);
        }

        public void NotNullMessageException(string value)
            => value.PrivateExpectNotNull<ArgumentException>(_scenario.Get<string>("message"));

        public void NotNullException(string value) => value.PrivateExpectNotNull<ArgumentException>();
        public void NotNullMessage(string value) => value.PrivateExpectNotNull(_scenario.Get<string>("message"));
        public void NotNull(string value) => value.PrivateExpectNotNull();

        public void NotNullAssertMessage(string value)
            => value.PrivateAssertNotNull(_scenario.Get<string>("message"));

        public void NotNullAssert(string value) => value.PrivateAssertNotNull();

        public void AssertMessage(string value)
            => ExpectPrivate.Assert(value != null, _scenario.Get<string>("message"));

        public void DoAssert(string value) => ExpectPrivate.Assert(value != null);

        [Given(@"a private method with a true check, custom message and ArgumentException")]
        public void GivenAPrivateMethodWithATrueCheckCustomMessageAndArgumentException()
            => _scenario.Set<Action>(() => TrueMessageException(null));

        [Given(@"a private method with a true check using ArgumentException")]
        public void GivenAPrivateMethodWithATrueCheckUsingArgumentException()
            => _scenario.Set<Action>(() => TrueException(null));

        [Given(@"a private method with a true check and custom message")]
        public void GivenAPrivateMethodWithATrueCheckAndCustomMessage()
            => _scenario.Set<Action>(() => TrueMessage(null));

        [Given(@"a private method with a true check")]
        public void GivenAPrivateMethodWithATrueCheck() => _scenario.Set<Action>(() => True(null));

        [Given(@"a private method with a not null check, custom message and ArgumentException")]
        public void GivenAPrivateMethodWithANotNullCheckCustomMessageAndArgumentException()
            => _scenario.Set<Action>(() => NotNullMessageException(null));

        [Given(@"a private method with a not null check using ArgumentException")]
        public void GivenAPrivateMethodWithANotNullCheckUsingArgumentException()
            => _scenario.Set<Action>(() => NotNullException(null));

        [Given(@"a private method with a not null check and custom message")]
        public void GivenAPrivateMethodWithANotNullCheckAndCustomMessage()
            => _scenario.Set<Action>(() => NotNullMessage(null));

        [Given(@"a private method with a not null check")]
        public void GivenAPrivateMethodWithANotNullCheck() => _scenario.Set<Action>(() => NotNull(null));

        [Given(@"a private method with a not null assertion check and custom message")]
        public void GivenAPrivateMethodWithANotNullAssertionCheckAndCustomMessage()
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

        [Given(@"a private method with a not null assertion check")]
        public void GivenAPrivateMethodWithANotNullAssertionCheck()
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

        [Given(@"a private method with an assertion check and custom message")]
        public void GivenAPrivateMethodWithAnAssertionCheckAndCustomMessage()
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

        [Given(@"a private method with an assertion check")]
        public void GivenAPrivateMethodWithAnAssertionCheck()
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

