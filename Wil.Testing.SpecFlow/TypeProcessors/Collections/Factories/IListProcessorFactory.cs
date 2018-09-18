using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IListProcessorFactory : SimpleCollectionProcessorFactory
    {
        public IListProcessorFactory(SpecFlowContext context)
            : base(typeof(IListProcessor<>), typeof(IList<>), context, "IList")
        {
        }
    }
}
