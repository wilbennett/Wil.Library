using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class CommonThenBindings : BindingsBase
    {
        public CommonThenBindings(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(scenarioContext, featureContext)
        {
        }

        [Then(@"(\w+) should exist")]
        public void ThenShouldExist(string key) => Assert.IsTrue(_scenario.ContainsKey(key), $"{key} should exist");

        [Then(@"(\w+) should not exist")]
        public void ThenShouldNotExist(string key)
            => Assert.IsFalse(_scenario.ContainsKey(key), $"{key} should not exist");
    }
}