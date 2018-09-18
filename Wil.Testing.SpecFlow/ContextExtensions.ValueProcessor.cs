using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public static partial class ContextExtensions
    {
        public static void AddValueProcessor(this SpecFlowContext context, IValueProcessor processor)
        {
            AddDefaultValueProcessors(context);
            Dictionary<string, IValueProcessor> lookup = GetValueProcessorLookup(context);
            Dictionary<Type, IValueProcessor> typeLookup = GetValueProcessorTypeLookup(context);
            List<IValueProcessor> order = GetValueProcessorOrder(context);

            processor.DataTypeNames.ForEach(n => lookup[n] = processor);
            typeLookup[processor.DataType] = processor;
            order.Insert(0, processor);
        }

        public static IValueProcessor GetValueProcessor(this SpecFlowContext context, string dataTypeName)
        {
            AddDefaultValueProcessors(context);
            var lookup = context.GetInherited<Dictionary<string, IValueProcessor>>("__processorLookup__");

            lookup.TryGetValue(dataTypeName, out IValueProcessor result);
            return result;
        }

        public static IValueProcessor GetValueProcessor(this SpecFlowContext context, Type dataType)
        {
            AddDefaultValueProcessors(context);
            var lookup = context.GetInherited<Dictionary<Type, IValueProcessor>>("__processorTypeLookup__");

            lookup.TryGetValue(dataType, out IValueProcessor result);
            return result;
        }

        public static List<IValueProcessor> GetValueProcessorOrder(this SpecFlowContext context)
        {
            AddDefaultValueProcessors(context);
            return context.GetInherited<List<IValueProcessor>>("__ValueProcessorOrder__");
        }

        public static void SetValueProcessorOrder(this SpecFlowContext context, List<IValueProcessor> values)
        {
            AddDefaultValueProcessors(context);
            context.Set(values, "__ValueProcessorOrder__");
        }

        private static Dictionary<string, IValueProcessor> GetValueProcessorLookup(this SpecFlowContext context)
            => context.GetEx<Dictionary<string, IValueProcessor>>("__processorLookup__");

        private static Dictionary<Type, IValueProcessor> GetValueProcessorTypeLookup(this SpecFlowContext context)
            => context.GetEx<Dictionary<Type, IValueProcessor>>("__processorTypeLookup__");

        private static void SetValueProcessorLookup(
            this SpecFlowContext context,
            Dictionary<string, IValueProcessor> value)
            => context.Set(value, "__processorLookup__");

        private static void SetValueProcessorLookup(
            this SpecFlowContext context,
            Dictionary<Type, IValueProcessor> value)
            => context.Set(value, "__processorTypeLookup__");

        private static void AddDefaultValueProcessors(this SpecFlowContext context)
        {
            const string defaultKey = "__defaultValueProcessorsAdded__";

            if (context.ContainsKey(defaultKey) && context.GetEx<bool>(defaultKey)) return;

            context.Set(true, defaultKey);

            var typeLookup = new Dictionary<Type, IValueProcessor>();
            var lookup = new Dictionary<string, IValueProcessor>(StringComparer.OrdinalIgnoreCase);
            var order = new List<IValueProcessor>();

            // Auto determine.
            Add(new BoolProcessor(context));
            Add(new IntProcessor(context));
            Add(new LongProcessor(context));
            Add(new ULongProcessor(context));
            Add(new DoubleProcessor(context));
            Add(new DurationProcessor(context));
            Add(new DateTimeProcessor(context));
            Add(new DateTimeOffsetProcessor(context));
            Add(new StringProcessor(context));
            Add(new ObjectProcessor(context));

            // Need to specify type to use.
            Add(new ByteProcessor(context));
            Add(new CharProcessor(context));
            Add(new SByteProcessor(context));
            Add(new UIntProcessor(context));
            Add(new ShortProcessor(context));
            Add(new UShortProcessor(context));
            Add(new FloatProcessor(context));
            Add(new DecimalProcessor(context));
            Add(new TimeSpanProcessor(context));

            SetValueProcessorLookup(context, lookup);
            SetValueProcessorLookup(context, typeLookup);
            SetValueProcessorOrder(context, order);

            void Add(IValueProcessor processor)
            {
                typeLookup.Add(processor.DataType, processor);
                processor.DataTypeNames.ForEach(n => lookup.Add(n, processor));
                order.Add(processor);
            }
        }
    }
}
