using System;
using TechTalk.SpecFlow;
using Wil.Contracts.Extensions;

namespace Wil.Contracts.specs
{
    [Binding]
    public class PublicContractFeatureSteps
    {
        public PublicContractFeatureSteps(ScenarioContext scenarioContext)
            => _scenario = scenarioContext;

        public void NotNullContract(string value) => value.RequireNotNull(nameof(value));

        public void TrueMessageException(string value)
            => Require.True<ArgumentException>(value != null, _scenario.Get<string>("message"));

        public void TrueException(string value) => Require.True<ArgumentException>(value != null);

        public void TrueMessage(string value)
            => Require.True(value != null, _scenario.Get<string>("message"));

        public void True(string value)
        {
            Require.True(value == null); // HACK: Test the passing condition in Require.True.
            Require.True(value != null);
        }

        [Given(@"a public method with a not null precondition")]
        public void GivenAPublicMethodWithANotNullPrecondition()
            => _scenario.Set<Action>(() => NotNullContract(null));

        [Given(@"a public method with a true precondition, custom message and ArgumentException")]
        public void GivenAPublicMethodWithATruePreconditionCustomMessageAndArgumentException()
            => _scenario.Set<Action>(() => TrueMessageException(null));

        [Given(@"a public method with a true precondition using ArgumentException")]
        public void GivenAPublicMethodWithATruePreconditionUsingArgumentException()
            => _scenario.Set<Action>(() => TrueException(null));

        [Given(@"a public method with a true precondition and custom message")]
        public void GivenAPublicMethodWithATruePreconditionAndCustomMessage()
            => _scenario.Set<Action>(() => TrueMessage(null));

        [Given(@"a public method with a true precondition")]
        public void GivenAPublicMethodWithATruePrecondition()
            => _scenario.Set<Action>(() => True(null));

        private readonly ScenarioContext _scenario;
    }
}

