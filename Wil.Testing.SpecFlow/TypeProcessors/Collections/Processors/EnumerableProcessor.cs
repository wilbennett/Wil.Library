using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public class EnumerableProcessor<T> : CollectionProcessor<IEnumerable<T>, T>
    {
        public EnumerableProcessor(IValueProcessor elementProcessor, SpecFlowContext context)
            : base(elementProcessor, context, $"{nameof(EnumerableProcessor<T>)}<{elementProcessor?.FriendlyTypeName}>")
        {
        }

        protected override ICollection ToCollection(IEnumerable<T> value) => value?.ToArray();
    }
}
