using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class SimpleCollectionProcessorFactory : CollectionProcessorFactory
    {
        public SimpleCollectionProcessorFactory(
            Type processorType,
            Type collectionType,
            SpecFlowContext context,
            params string[] collectionKindNames)
            : base(context, collectionKindNames)
        {
            _processorType = processorType;
            _collectionType = collectionType;
        }

        public override bool CanHandle(Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == _collectionType;

        protected readonly Type _processorType;
        protected readonly Type _collectionType;

        protected override Type GetElementTypeCore(Type existingType) => existingType.GetGenericArguments()[0];

        protected override ICollectionProcessor CreateCore(IValueProcessor elementProcessor)
        {
            Type processorType = _processorType.MakeGenericType(elementProcessor.DataType);
            return (ICollectionProcessor)Activator.CreateInstance(processorType, elementProcessor, Context);
        }
    }
}
