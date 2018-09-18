using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IReadOnlyListProcessor<T> : CollectionProcessor<IReadOnlyList<T>, T>
    {
        public IReadOnlyListProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(IReadOnlyListProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }
    }
}
