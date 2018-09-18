using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IReadOnlyListProcessorFactory : SimpleCollectionProcessorFactory
    {
        public IReadOnlyListProcessorFactory(SpecFlowContext context)
            : base(typeof(IReadOnlyListProcessor<>), typeof(IReadOnlyList<>), context, "IReadOnlyList")
        {
        }
    }
}
