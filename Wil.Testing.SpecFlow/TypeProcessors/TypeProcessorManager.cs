using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public class TypeProcessorManager
    {
        public TypeProcessorManager(SpecFlowContext context)
        {
            _context = context;

            _processors = _context.GetValueProcessorOrder();
        }

        public ITypeProcessor GetProcessorForExistingName(string existingName)
        {
            //Console.WriteLine($"***** Getting processor for name: <{existingName}>");
            if (string.IsNullOrEmpty(existingName)) return null;

            if (GetCollectionProcessorForExistingName(existingName, out ITypeProcessor processor))
                return processor;

            var resultValue = _context.GetEx<object>(existingName);

            if (resultValue == null) return new ObjectProcessor(_context);
            //Console.WriteLine($"***** Getting processor for name: <{existingName}>... resultValue is <{resultValue}>");

            if (!GetProcessorForDataType(resultValue.GetType(), out processor))
                processor = new ObjectProcessor(_context);

            //processor.ReadFromContext(existingName);
            processor.SetValue(resultValue);
            //Console.WriteLine($"***** Getting processor for name: <{existingName}>... processor is <{processor}>");
            return processor;
        }

        public bool GetProcessorForExistingName(string resultName, out ITypeProcessor processor)
        {
            processor = GetProcessorForExistingName(resultName);
            return processor != null;
        }

        public ITypeProcessor GetProcessorForDataType(string dataTypeName)
            => !string.IsNullOrEmpty(dataTypeName) ? _context.GetValueProcessor(dataTypeName)?.Clone() : null;

        public bool GetProcessorForDataType(string dataTypeName, out ITypeProcessor processor)
        {
            processor = GetProcessorForDataType(dataTypeName);
            return processor != null;
        }

        public ITypeProcessor GetProcessorFor(Type dataType)
            => _context.GetValueProcessor(dataType)?.Clone();

        public bool GetProcessorForDataType(Type dataType, out ITypeProcessor processor)
        {
            processor = GetProcessorFor(dataType);
            return processor != null;
        }

        public ITypeProcessor GetProcessorForValue(string value)
            => _processors.FirstOrDefault(p => p.CanParse(value))?.Clone();

        public bool GetProcessorForValue(string value, out ITypeProcessor processor)
        {
            processor = GetProcessorForValue(value);
            return processor != null;
        }

        public ITypeProcessor GetProcessorFor(string dataTypeName, string value)
        {
            if (string.IsNullOrEmpty(dataTypeName))
                return GetProcessorForValue(value);

            ITypeProcessor processor = GetProcessorForDataType(dataTypeName);

            if (processor == null) ThrowMissingTypeName(dataTypeName);

            processor?.Parse(value);
            return processor;
        }

        public ITypeProcessor GetCollectionProcessorForExistingName(string resultName)
        {
            if (string.IsNullOrEmpty(resultName)) return null;

            var resultValue = _context.GetEx<object>(resultName);

            if (resultValue == null) return null;

            Type resultType = resultValue.GetType();

            ICollectionProcessor processor = _context.GetCollectionProcessorFactories()
                .Select(f => f.Create(resultType))
                .FirstOrDefault(f => f != null);

            processor?.ReadFromContext(resultName);
            //Console.WriteLine($"***** Got processor1: {(processor != null ? processor.ToString() : "NULL")}");
            return processor;
        }

        public bool GetCollectionProcessorForExistingName(string resultName, out ITypeProcessor processor)
        {
            processor = GetCollectionProcessorForExistingName(resultName);
            return processor != null;
        }

        public ITypeProcessor GetCollectionProcessorFor(string collectionKind, IValueProcessor processor)
        {
            if (processor == null) return null;

            CollectionProcessorFactory factory = !string.IsNullOrEmpty(collectionKind)
                ? _context.GetCollectionProcessorFactory(collectionKind)
                : _context.GetDefaultCollectionProcessorFactory();

            //Console.WriteLine($"***** Got processor factory: {factory?.GetType().Name}");

            if (factory == null) throw new Exception($"No registered CollectionProcessor for: {collectionKind}.");

            return factory.Create(processor);
        }

        public ITypeProcessor GetCollectionProcessorForValue(string collectionKind, string value)
        {
            List<string> values = value.ToStringsList();
            IValueProcessor elementProcessor = _processors.FirstOrDefault(p => values.All(p.CanParse));
            var collectionProcessor = GetCollectionProcessorFor(collectionKind, elementProcessor) as ICollectionProcessor;
            collectionProcessor?.SetValue(values);
            return collectionProcessor;
        }

        public ITypeProcessor GetCollectionProcessorFor(string dataTypeName, string value)
        {
            if (string.IsNullOrEmpty(dataTypeName))
                return GetCollectionProcessorForValue(null, value);

            IValueProcessor elementProcessor = GetProcessorForDataType(dataTypeName) as IValueProcessor;

            if (elementProcessor == null) ThrowMissingTypeName(dataTypeName);

            ITypeProcessor processor = GetCollectionProcessorFor(null, elementProcessor);

            if (value != null)
                processor.SetValue(value);

            return processor;
        }

        public ITypeProcessor GetCollectionProcessorFor(string collectionKind, string dataTypeName, string value)
        {
            //Console.WriteLine($"*** GetCollectionProcessorFor(<{collectionKind}>, <{dataTypeName}>, <{(value == null ? "NULL" : value)}>)");

            if (string.IsNullOrEmpty(collectionKind))
                return GetCollectionProcessorFor(dataTypeName, value);

            if (string.IsNullOrEmpty(dataTypeName))
                return GetCollectionProcessorForValue(collectionKind, value);

            IValueProcessor elementProcessor = GetProcessorForDataType(dataTypeName) as IValueProcessor;

            if (elementProcessor == null) ThrowMissingTypeName(dataTypeName);

            ITypeProcessor processor = GetCollectionProcessorFor(collectionKind, elementProcessor);

            if (value != null)
                processor.SetValue(value);

            return processor;
        }

        protected static void ThrowMissingTypeName(string typeName)
            => throw new Exception($"No registered TypeProcessor for type: {typeName}.");

        private readonly SpecFlowContext _context;
        private readonly List<IValueProcessor> _processors;
    }
}
