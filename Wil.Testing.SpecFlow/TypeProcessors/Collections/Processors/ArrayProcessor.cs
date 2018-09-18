using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public class ArrayProcessor<T> : CollectionProcessor<T[], T>
    {
        public ArrayProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{elementProcessor?.FriendlyTypeName}[]")
        {
        }

        protected override T[] ConvertToValue(IEnumerable<T> items) => items.ToArray();
    }
}
