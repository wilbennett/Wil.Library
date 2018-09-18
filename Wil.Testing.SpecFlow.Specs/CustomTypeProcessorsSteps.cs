using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Specs
{
    [Binding]
    [Scope(Tag = "customType")]
    public class CustomTypeProcessorsSteps
    {
        public CustomTypeProcessorsSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [BeforeScenario]
        public void RegisterCustomTypes()
        {
            _scenario.AddValueProcessor(new PersonProcessor(_scenario));
            _scenario.AddCollectionProcessorFactory(new CustomListProcessorFactory(_scenario));
        }

        private readonly ScenarioContext _scenario;
    }
}

