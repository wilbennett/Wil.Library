using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ListProcessorFactory : SimpleCollectionProcessorFactory
    {
        public ListProcessorFactory(SpecFlowContext context)
            : base(typeof(ListProcessor<>), typeof(List<>), context, "List")
        {
        }
    }
}
