#if !DEBUG
#define RELEASE
#endif

#if PUBLIC_CONTRACTS || PUBLIC_CHECKS || PRIVATE_CONTRACTS || PRIVATE_CHECKS
#define ENABLED
#endif

#if DEBUG && ENABLED
#define ASSERTIONS_ENABLED
#endif

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Wil.Contracts.Specs
{
    [Binding]
    public class CommonFeatureSteps
    {
        public CommonFeatureSteps(ScenarioContext scenarioContext) => _scenario = scenarioContext;

        [When(@"the method is called")]
        public void WhenTheMethodIsCalled()
        {
#if ENABLED
            try
            {
#endif
                Action method = _scenario.Get<Action>();
                method();
#if ENABLED
            }
            catch (Exception ex)
            {
                _scenario.Set(ex, "exception");
                _scenario.Set(ex.Message, "exceptionMessage");
            }
#endif
        }

#if ASSERTIONS_ENABLED
        [Then(@"the method should have asserted")]
        public void ThenTheMethodShouldHaveAsserted()
            => Assert.IsTrue(
                _scenario.TryGetValue("exception", out Exception exception),
                "Should assert in debug mode with checks enabled");

        [Then(@"the assertion message should be ""(.*)""")]
        public void ThenTheAssertionMessageShouldBe(string expected)
        {
            Assert.AreEqual(expected, _scenario.Get<string>("exceptionMessage"));
        }

#else
        [Then(@"the method should have asserted")]
        public void ThenTheMethodShouldNotHaveAsserted()
            => Assert.IsFalse(
                _scenario.TryGetValue("exception", out Exception exception),
                "Should not assert if not in debug mode or checks are not enabled");

        [Then(@"the assertion message should be ""(.*)""")]
        public void ThenTheAssertionMessageShouldBe(string expected)
        {
            Assert.IsFalse(
                _scenario.TryGetValue<string>("exceptionMessage", out string message),
                "no message expected if not in debug mode or checks are not enabled");
        }
#endif

#if ENABLED
        [Then(@"the method should have failed if enabled")]
        public void ThenTheMethodShouldHaveFailedIfEnabled()
            => Assert.IsTrue(_scenario.TryGetValue("exception", out Exception exception));

        [Then(@"the exceptionMessage should be ""(.*)"" if enabled")]
        public void ThenTheExceptionMessageShouldBeIfEnabled(string expected)
            => Assert.AreEqual(expected, _scenario.Get<string>("exceptionMessage"));

        [Then(@"the type of the exception should be ArgumentException if enabled")]
        public void ThenTheTypeOfTheExceptionShouldBeArgumentExceptionIfEnabled()
            => Assert.IsInstanceOfType(_scenario.Get<Exception>("exception"), typeof(ArgumentException));
#else
        [Then(@"the method should have failed if enabled")]
        public void ThenTheMethodShouldNotHaveFailedIfDisEnabled()
            => Assert.IsFalse(
            _scenario.TryGetValue("exception", out Exception exception),
            "Should not fail if checks are not enabled");

        [Then(@"the exceptionMessage should be ""(.*)"" if enabled")]
        public void ThenTheExceptionMessageShouldBeNullIfDisabled(string expected)
            => Assert.IsFalse(
                _scenario.TryGetValue<string>("exceptionMessage", out string message),
                "no message expected if checks are not enabled");

        [Then(@"the type of the exception should be ArgumentException if enabled")]
        public void ThenTheTypeOfTheExceptionShouldBeNullIfDisabled()
        {
            // No exception if not enabled.  Tested when checking for exceptions.
        }
#endif

        private readonly ScenarioContext _scenario;
    }
}

