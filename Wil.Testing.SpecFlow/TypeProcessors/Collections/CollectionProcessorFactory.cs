using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public abstract class CollectionProcessorFactory
    {
        public CollectionProcessorFactory(SpecFlowContext context, params string[] collectionKindNames)
        {
            Context = context;
            CollectionKindNames = collectionKindNames;
        }

        public SpecFlowContext Context { get; }
        public IList<string> CollectionKindNames { get; }

        public ICollectionProcessor Create(IValueProcessor elementProcessor) => CreateCore(elementProcessor);

        public ICollectionProcessor Create(Type existingType)
        {
            Type elementType = GetElementType(existingType);

            if (elementType == null) return null;

            IValueProcessor elementProcessor = Context.GetValueProcessor(elementType);
            return Create(elementProcessor);
        }

        public Type GetElementType(Type existingType)
            => CanHandle(existingType) ? GetElementTypeCore(existingType) : null;

        public abstract bool CanHandle(Type type);
        protected abstract Type GetElementTypeCore(Type existingType);
        protected abstract ICollectionProcessor CreateCore(IValueProcessor elementProcessor);
    }
}
