using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IReadOnlyCollectionProcessorFactory : SimpleCollectionProcessorFactory
    {
        public IReadOnlyCollectionProcessorFactory(SpecFlowContext context)
            : base(
                  typeof(IReadOnlyCollectionProcessor<>),
                  typeof(IReadOnlyCollection<>),
                  context,
                  "IReadOnlyCollection")
        {
        }
    }
}
