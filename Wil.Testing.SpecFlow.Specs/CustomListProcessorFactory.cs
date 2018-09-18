using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Specs
{
    public class CustomListProcessorFactory : SimpleCollectionProcessorFactory
    {
        public CustomListProcessorFactory(SpecFlowContext context)
            : base(typeof(CustomListProcessor<>), typeof(List<>), context, "CustomList")
        {
        }
    }
}

