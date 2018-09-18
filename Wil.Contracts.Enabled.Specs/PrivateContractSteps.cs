using System;
using TechTalk.SpecFlow;
using Wil.Contracts.Extensions;

namespace Wil.Contracts.specs
{
    [Binding]
    public class PrivateContractFeatureSteps
    {
        public PrivateContractFeatureSteps(ScenarioContext scenarioContext)
            => _scenario = scenarioContext;

        public void NotNullContract(string value) => value.PrivateRequireNotNull(nameof(value));

        public void TrueMessageException(string value)
            => RequirePrivate.True<ArgumentException>(value != null, _scenario.Get<string>("message"));

        public void TrueException(string value) => RequirePrivate.True<ArgumentException>(value != null);

        public void TrueMessage(string value)
            => RequirePrivate.True(value != null, _scenario.Get<string>("message"));

        public void True(string value)
        {
            RequirePrivate.True(value == null); // HACK: Test the passing condition in RequirePrivate.True.
            RequirePrivate.True(value != null);
        }

        [Given(@"a private method with a not null precondition")]
        public void GivenAPrivateMethodWithANotNullPrecondition()
            => _scenario.Set<Action>(() => NotNullContract(null));

        [Given(@"a private method with a true precondition, custom message and ArgumentException")]
        public void GivenAPrivateMethodWithATruePreconditionCustomMessageAndArgumentException()
            => _scenario.Set<Action>(() => TrueMessageException(null));

        [Given(@"a private method with a true precondition using ArgumentException")]
        public void GivenAPrivateMethodWithATruePreconditionUsingArgumentException()
            => _scenario.Set<Action>(() => TrueException(null));

        [Given(@"a private method with a true precondition and custom message")]
        public void GivenAPrivateMethodWithATruePreconditionAndCustomMessage()
            => _scenario.Set<Action>(() => TrueMessage(null));

        [Given(@"a private method with a true precondition")]
        public void GivenAPrivateMethodWithATruePrecondition() => _scenario.Set<Action>(() => True(null));

        private readonly ScenarioContext _scenario;
    }
}

