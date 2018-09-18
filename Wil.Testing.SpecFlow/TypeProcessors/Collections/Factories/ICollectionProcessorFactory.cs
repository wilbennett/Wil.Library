using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ICollectionProcessorFactory : SimpleCollectionProcessorFactory
    {
        public ICollectionProcessorFactory(SpecFlowContext context)
            : base(typeof(ICollectionProcessor<>), typeof(ICollection<>), context, "ICollection")
        {
        }
    }
}
