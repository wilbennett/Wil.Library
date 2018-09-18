using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public static partial class ContextExtensions
    {
        //public static IComparer GetComparer(this SpecFlowContext context, string typeName)
        //{
        //    Dictionary<string, ComparerMapping> mapping = GetComparerStringMappingLookup(context);
        //    ComparerMapping result;
        //    mapping.TryGetValue(typeName, out result);
        //    return result.Comparer;
        //}

        public static IComparer GetComparer(this SpecFlowContext context, Type type)
        {
            Dictionary<Type, ComparerMapping> mapping = GetComparerTypeMappingLookup(context);
            ComparerMapping result;
            mapping.TryGetValue(type, out result);
            return result.Comparer;
        }

        public static void AddComparerMapping(this SpecFlowContext context, ComparerMapping mapping)
        {
            // TODO: Consider only adding to the current context instead of the inherited context.
            Dictionary<string, ComparerMapping> stringLookup = GetComparerStringMappingLookup(context);
            stringLookup[mapping.TypeName] = mapping;

            Dictionary<Type, ComparerMapping> typeLookup = GetComparerTypeMappingLookup(context);
            typeLookup[mapping.Type] = mapping;
        }

        private static Dictionary<string, ComparerMapping> GetComparerStringMappingLookup(
            this SpecFlowContext context)
        {
            AddDefaultComparerMappings(context);
            return context.GetInherited<Dictionary<string, ComparerMapping>>("__comparerStringMappingLookup__");
        }

        private static void SetComparerStringMappingLookup(
            this SpecFlowContext context,
            Dictionary<string, ComparerMapping> value)
            => context.Set(value, "__comparerStringMappingLookup__");

        private static Dictionary<Type, ComparerMapping> GetComparerTypeMappingLookup(this SpecFlowContext context)
        {
            AddDefaultComparerMappings(context);
            return context.GetInherited< Dictionary<Type, ComparerMapping>>("__comparerTypeMappingLookup__");
        }

        private static void SetComparerTypeMappingLookup(
            this SpecFlowContext context,
            Dictionary<Type, ComparerMapping> value)
            => context.Set(value, "__comparerTypeMappingLookup__");

        private static void AddDefaultComparerMappings(this SpecFlowContext context)
        {
            const string defaultKey = "__defaultComparersAdded__";

            if (context.GetInheritedOrDefault(defaultKey, false)) return;

            context.Set(true, defaultKey);

            var stringLookup = new Dictionary<string, ComparerMapping>(StringComparer.OrdinalIgnoreCase);
            var typeLookup = new Dictionary<Type, ComparerMapping>();
            SetComparerStringMappingLookup(context, stringLookup);
            SetComparerTypeMappingLookup(context, typeLookup);

            Add(new DoubleComparer(context), typeof(double), "Double");
            Add(new FloatComparer(context), typeof(float), "Float", "Single");

            void Add(IComparer comparer, Type type, params string[] keys)
            {
                foreach (string key in keys)
                {
                    AddComparerMapping(context, new ComparerMapping(key, type, comparer));
                }
            }
        }
    }
}
