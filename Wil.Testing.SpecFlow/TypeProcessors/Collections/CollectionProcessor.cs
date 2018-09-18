using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public abstract class CollectionProcessor<T, TElement> : TypeProcessor<T>, ICollectionProcessor
        where T: class
    {
        public CollectionProcessor(IValueProcessor elementProcessor, SpecFlowContext context, string friendlyTypeName)
            : base(context, friendlyTypeName)
        {
            ElementProcessor = elementProcessor;

            if (ElementProcessor?.DataType != typeof(TElement))
            {
                throw new ArgumentException(
                    $"{nameof(elementProcessor)} cannot be null and must be an {nameof(IValueProcessor)} with {nameof(DataType)} {DataType.Name}.",
                    nameof(elementProcessor));
            }
        }

        public Type ElementType { get; } = typeof(TElement);
        public string ElementTypeName { get; } = typeof(TElement).FullName;
        public IValueProcessor ElementProcessor { get; }
        public ICollection CollectionValue { get; private set; }
        public override bool CanParseEmptyString => true;

        public void SetValue(List<string> texts)
        {
            ClearValue();
            T value = ParseCore(texts);
            UpdateValue(value);
        }

        public override void CompareTo(ITypeProcessor other, CompareOp compareOp)
        {
            ICollection otherValue;
            //Console.WriteLine($"***** Comparing {this} {compareOp} {other}");

            switch (compareOp)
            {
                case CompareOp.Null:
                    Assert.IsNull(Value);
                    break;

                case CompareOp.NotNull:
                    Assert.IsNotNull(Value);
                    break;

                case CompareOp.Equal:
                    otherValue = GetCollectionToCompareTo(other);
                    CollectionAssert.AreEqual(otherValue, CollectionValue, Comparer, $"{this} is not equal to {other}");
                    break;

                case CompareOp.NotEqual:
                    otherValue = GetCollectionToCompareTo(other);
                    CollectionAssert.AreNotEqual(otherValue, CollectionValue, Comparer, $"{this} is equal to {other}");
                    break;

                case CompareOp.Equivalent:
                    otherValue = GetCollectionToCompareTo(other);
                    CollectionAssert.AreEquivalent(otherValue, CollectionValue, $"{this} is not equivalent to {other}");
                    break;

                case CompareOp.NotEquivalent:
                    otherValue = GetCollectionToCompareTo(other);
                    CollectionAssert.AreNotEquivalent(otherValue, CollectionValue, $"{this} is equivalent to {other}");
                    break;

                case CompareOp.Contain:
                    otherValue = GetCollectionToCompareTo(other);
                    CollectionAssert.IsSubsetOf(otherValue, CollectionValue, $"{this} does not contain {other}");
                    break;

                case CompareOp.NotContain:
                    otherValue = GetCollectionToCompareTo(other);
                    CollectionAssert.IsNotSubsetOf(otherValue, CollectionValue, $"{this} contains {other}");
                    break;

                case CompareOp.Match:
                case CompareOp.NotMatch:
                case CompareOp.Greater:
                case CompareOp.GreaterOrEqual:
                case CompareOp.NotGreater:
                case CompareOp.NotGreaterOrEqual:
                case CompareOp.Less:
                case CompareOp.LessOrEqual:
                case CompareOp.NotLess:
                case CompareOp.NotLessOrEqual:
                default:
                    ThrowCompareOpNotSupported(compareOp); break;
            }
        }

        public override string ToString()
            => $"{FriendlyTypeName}: <{(Value == null ? "NULL" : string.Join(", ", (IEnumerable<TElement>)Value))}>"
            .Clip(ClipLength);

        protected sealed override T ParseCore(string text) => ParseCore(text.ToStringsList());

        protected virtual T ParseCore(List<string> text)
        {
            Console.WriteLine($"***** Parsing {string.Join(", ", text.Select(x => $"<{x}>"))}");
            return ConvertToValue(text.Select(value => (TElement)ElementProcessor.Parse(value)));
        }

        protected override TypeProcessor<T> CloneCore()
            => (TypeProcessor<T>)Activator.CreateInstance(GetType(), ElementProcessor.Clone(), Context);

        protected virtual T ConvertToValue(IEnumerable<TElement> items) => items.ToList() as T;
        protected virtual ICollection ToCollection(T value) => value as ICollection;
        protected override IComparer Comparer => Context.GetComparer(DataType);

        protected override void ClearValueCore() => CollectionValue = null;
        protected override void UpdateValueCore(object value) => CollectionValue = ToCollection((T)Value);

        protected ICollection GetCollectionToCompareTo(ITypeProcessor other)
        {
            if (other is ICollectionProcessor otherCollection)
                return otherCollection.CollectionValue;

            throw new ArgumentException(
                $"Cannot compare {this} to {other}.  Can only compare to another {nameof(ICollectionProcessor)}",
                nameof(other));
        }
    }
}
