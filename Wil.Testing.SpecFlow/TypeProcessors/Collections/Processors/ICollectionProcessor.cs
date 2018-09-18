using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ICollectionProcessor<T> : CollectionProcessor<ICollection<T>, T>
    {
        public ICollectionProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(ICollectionProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }
    }
}
