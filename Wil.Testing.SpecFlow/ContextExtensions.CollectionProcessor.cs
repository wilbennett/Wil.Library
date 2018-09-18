using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public static partial class ContextExtensions
    {
        public static List<CollectionProcessorFactory> GetCollectionProcessorFactories(this SpecFlowContext context)
        {
            AddDefaultCollectionProcessorFactories(context);

            var lookup = context.GetInheritedOrDefault<Dictionary<string, CollectionProcessorFactory>>(
                    "__collectionProcessorLookup__", null);

            if (lookup == null) return new List<CollectionProcessorFactory>();

            return lookup.Values.ToList();
        }

        public static void AddCollectionProcessorFactory(
            this SpecFlowContext context,
            CollectionProcessorFactory factory)
        {
            AddDefaultCollectionProcessorFactories(context);
            Dictionary<string, CollectionProcessorFactory> lookup = GetCollectionProcessorFactoryLookup(context);

            factory.CollectionKindNames.ForEach(n => lookup[n] = factory);
        }

        public static CollectionProcessorFactory GetCollectionProcessorFactory(
            this SpecFlowContext context,
            string collectionKind)
        {
            AddDefaultCollectionProcessorFactories(context);

            var lookup = context.GetInheritedOrDefault<Dictionary<string, CollectionProcessorFactory>>(
                    "__collectionProcessorLookup__", null);

            if (lookup == null) return null;

            lookup.TryGetValue(collectionKind, out CollectionProcessorFactory result);
            return result;
        }

        public static void SetDefaultCollectionProcessorFactory(
            this SpecFlowContext context,
            CollectionProcessorFactory factory)
        {
            AddDefaultCollectionProcessorFactories(context);
            context.Set(factory, "__defaultCollectionProcessorFactory__");
        }

        public static CollectionProcessorFactory GetDefaultCollectionProcessorFactory(
            this SpecFlowContext context)
        {
            AddDefaultCollectionProcessorFactories(context);
            return context.GetInheritedOrDefault<CollectionProcessorFactory>("__defaultCollectionProcessorFactory__", null);
        }

        private static Dictionary<string, CollectionProcessorFactory> GetCollectionProcessorFactoryLookup(
            this SpecFlowContext context)
            => context.GetEx<Dictionary<string, CollectionProcessorFactory>>("__collectionProcessorLookup__");

        private static void SetCollectionProcessorFactoryLookup(
            this SpecFlowContext context,
            Dictionary<string, CollectionProcessorFactory> value)
            => context.Set(value, "__collectionProcessorLookup__");

        private static void AddDefaultCollectionProcessorFactories(this SpecFlowContext context)
        {
            const string defaultKey = "__defaultCollectionProcessorFactoriesAdded__";

            if (context.ContainsKey(defaultKey) && context.GetEx<bool>(defaultKey)) return;

            context.Set(true, defaultKey);

            var lookup = new Dictionary<string, CollectionProcessorFactory>(StringComparer.OrdinalIgnoreCase);
            var listProcessor = new ListProcessorFactory(context);

            AddToLookup(new ArrayProcessorFactory(context));
            AddToLookup(new EnumerableProcessorFactory(context));
            AddToLookup(new ICollectionProcessorFactory(context));
            AddToLookup(new IListProcessorFactory(context));
            AddToLookup(new IReadOnlyCollectionProcessorFactory(context));
            AddToLookup(new IReadOnlyListProcessorFactory(context));
            AddToLookup(listProcessor);

            SetCollectionProcessorFactoryLookup(context, lookup);
            SetDefaultCollectionProcessorFactory(context, listProcessor);

            void AddToLookup(CollectionProcessorFactory factory)
                => factory.CollectionKindNames.ForEach(n => lookup.Add(n, factory));
        }
    }
}
