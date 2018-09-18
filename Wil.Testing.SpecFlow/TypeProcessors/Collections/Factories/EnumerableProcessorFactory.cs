using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class EnumerableProcessorFactory : SimpleCollectionProcessorFactory
    {
        public EnumerableProcessorFactory(SpecFlowContext context)
            : base(typeof(EnumerableProcessor<>), typeof(IEnumerable<>), context, "enumerable")
        {
        }
    }
}
