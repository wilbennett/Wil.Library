using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Specs
{
    [Binding]
    public class GeneratedBindingErrorsSteps
    {
        public GeneratedBindingErrorsSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
        }

        [Given("(.+) is an IntProcessor")]
        public void GivenIsAnIntProcessor(string key)
        {
            IValueProcessor processor = new IntProcessor(_scenario);
            _scenario.Set(processor, key);
        }

        [Given("(.+) is a null IntProcessor")]
        public void GivenIsANullIntProcessor(string key) => _scenario.Set<IValueProcessor>(null, key);

        [Given("(.+) is a CustomListProcessor with (.+)")]
        public void GivenIsACustomListProcessorWith(string processorKey, string elementProcessorKey)
        {
            var elementProcessor = _scenario.GetEx<IValueProcessor>(elementProcessorKey);
            var factory = new CustomListProcessorFactory(_scenario);
            ICollectionProcessor processor = factory.Create(elementProcessor);

            _scenario.Set(processor, processorKey);
        }

        [When("an integer ListProcessor is created with processor (.+)")]
        public void WhenAListProcessorIsCreatedWithProcessor(string processorKey)
        {
            var processor = _scenario.GetEx<IValueProcessor>(processorKey);

            try
            {
                new ListProcessor<int>(processor, _scenario);
            }
            catch (Exception ex)
            {
                _scenario.Set(ex, "exception");
            }
        }

        [When(@"(.+)\.CompareTo is called with (.+)")]
        public void WhenCompareToIsCalledWith(string firstKey, string secondKey)
        {
            var firstProcessor = _scenario.GetEx<ITypeProcessor>(firstKey);
            var secondProcessor = _scenario.GetEx<ITypeProcessor>(secondKey);

            try
            {
                firstProcessor.CompareTo(secondProcessor, CompareOp.Equal);
            }
            catch (Exception ex)
            {
                _scenario.Set(ex, "exception");
            }
        }

        private readonly ScenarioContext _scenario;
    }
}

