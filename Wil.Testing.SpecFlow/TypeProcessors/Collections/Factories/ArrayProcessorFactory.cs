using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ArrayProcessorFactory : SimpleCollectionProcessorFactory
    {
        public ArrayProcessorFactory(SpecFlowContext context)
            : base(typeof(ArrayProcessor<>), null, context, "array")
        {
        }

        public override bool CanHandle(Type type)
            => type.IsArray && type.GetArrayRank() == 1 && !type.GetElementType().IsArray;

        protected override Type GetElementTypeCore(Type type) => type.GetElementType();
    }
}
