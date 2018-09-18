using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public abstract class ValueProcessor<T> : TypeProcessor<T>, IValueProcessor
    {
        public ValueProcessor(SpecFlowContext context, string friendlyTypeName, params string[] dataTypeNames)
            : base(context, friendlyTypeName)
        {
            DataTypeNames = dataTypeNames;
        }

        public IList<string> DataTypeNames { get; }

        IValueProcessor IValueProcessor.Clone() => Clone() as IValueProcessor;

        public override void CompareTo(ITypeProcessor other, CompareOp compareOp)
        {
            IComparer comparer = Context.GetComparer(DataType);
            T otherValue;
            T value = (T)Value;
            string thisString;
            string otherString;

            switch (compareOp)
            {
                case CompareOp.Null:
                    Assert.IsNull(Value);
                    break;

                case CompareOp.NotNull:
                    Assert.IsNotNull(Value);
                    break;

                case CompareOp.Match:
                    thisString = Value.ToString();
                    otherString = other.Value.ToString();
                    Assert.IsTrue(Regex.IsMatch(thisString, otherString), $"{thisString} does not match {otherString}");
                    break;

                case CompareOp.NotMatch:
                    thisString = Value.ToString();
                    otherString = other.Value.ToString();
                    Assert.IsFalse(Regex.IsMatch(thisString, otherString), $"{thisString} matches {otherString}");
                    break;

                case CompareOp.Equal:
                case CompareOp.Equivalent:
                    otherValue = GetValue(other);

                    if (comparer == null)
                        Assert.AreEqual(otherValue, value);
                    else
                        Assert.IsTrue(Comparer.Compare(value, otherValue) == 0, $"Expected {value} = {otherValue}");
                    break;

                case CompareOp.NotEqual:
                case CompareOp.NotEquivalent:
                    otherValue = GetValue(other);

                    if (comparer == null)
                        Assert.AreNotEqual(otherValue, value);
                    else
                        Assert.IsTrue(Comparer.Compare(value, otherValue) != 0, $"Expected {value} <> {otherValue}");
                    break;

                case CompareOp.Greater:
                case CompareOp.NotLessOrEqual:
                    otherValue = GetValue(other);
                    Assert.IsTrue(Comparer.Compare(value, otherValue) > 0, $"Expected {value} > {otherValue}");
                    break;

                case CompareOp.NotGreater:
                case CompareOp.LessOrEqual:
                    otherValue = GetValue(other);
                    Assert.IsTrue(Comparer.Compare(value, otherValue) <= 0, $"Expected {value} <= {otherValue}");
                    break;

                case CompareOp.NotGreaterOrEqual:
                case CompareOp.Less:
                    otherValue = GetValue(other);
                    Assert.IsTrue(Comparer.Compare(value, otherValue) < 0, $"Expected {value} < {otherValue}");
                    break;

                case CompareOp.GreaterOrEqual:
                case CompareOp.NotLess:
                    otherValue = GetValue(other);
                    Assert.IsTrue(Comparer.Compare(value, otherValue) >= 0, $"Expected {value} >= {otherValue}");
                    break;

                case CompareOp.Contain:
                case CompareOp.NotContain:
                case CompareOp.Unknown:
                default:
                    ThrowCompareOpNotSupported(compareOp); break;
            }
        }

        public override string ToString()
            => $"{FriendlyTypeName}: <{(Value == null ? "NULL" : ((T)Value).ToString())}>".Clip(ClipLength);

        protected override TypeProcessor<T> CloneCore()
            => (TypeProcessor<T>)Activator.CreateInstance(GetType(), Context);

        protected T GetValue(ITypeProcessor processor)
        {
            //if (processor is IValueProcessor processorT
            //)
            //{
            //    return (T)processorT.Value;
            //}
            //else
            {
                return (T)Convert.ChangeType(processor.Value, DataType);
            }
        }
    }
}
