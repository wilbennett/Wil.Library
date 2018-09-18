using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Specs
{
    public class CustomListProcessor<T> : CollectionProcessor<List<T>, T>
    {
        public CustomListProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(CustomListProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }
    }
}

