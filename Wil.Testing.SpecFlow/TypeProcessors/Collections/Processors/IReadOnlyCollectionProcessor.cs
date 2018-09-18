using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IReadOnlyCollectionProcessor<T> : CollectionProcessor<IReadOnlyCollection<T>, T>
    {
        public IReadOnlyCollectionProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(IReadOnlyCollectionProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }
    }
}
