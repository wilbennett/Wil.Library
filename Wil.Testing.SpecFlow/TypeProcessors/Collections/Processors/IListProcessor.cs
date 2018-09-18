using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IListProcessor<T> : CollectionProcessor<IList<T>, T>
    {
        public IListProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(IListProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }
    }
}
