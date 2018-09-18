using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ListProcessor<T> : CollectionProcessor<List<T>, T>
    {
        public ListProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(ListProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }
    }
}
