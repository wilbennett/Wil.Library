using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public abstract class TypeProcessor<T> : ITypeProcessor
    {
        public TypeProcessor(SpecFlowContext context, string friendlyTypeName)
        {
            Context = context;
            FriendlyTypeName = friendlyTypeName;
        }

        public SpecFlowContext Context { get; }
        public Type DataType { get; } = typeof(T);
        public string DataTypeName { get; } = typeof(T).FullName;
        public string FriendlyTypeName { get; }
        public object Value { get; private set; }
        public virtual bool CanParseEmptyString => false;

        public ITypeProcessor Clone()
        {
            TypeProcessor<T> result = CloneCore();
            result.UpdateValue(Value);
            return result;
        }

        public bool CanParse(string text)
        {
            ClearValue();

            if (!CanParseEmptyString && text == string.Empty) return false;
            if (!TryParse(text, out T value)) return false;

            UpdateValue(value);
            return true;
        }

        public object Parse(string text)
        {
            ClearValue();

            if (text == null) return null;
            if (!CanParseEmptyString && text == string.Empty) ThrowCannotParseEmptyString();

            UpdateValue(ParseCore(text));
            return Value;
        }

        public virtual void SetValue(string text) => Parse(text);

        public virtual void SetValue(object value)
        {
            ClearValue();

            UpdateValue((T)value);
        }

        public void ReadFromContext(string name = null)
        {
            ClearValue();
            UpdateValue(ReadFromContextCore(name));
            //Console.WriteLine($"***** {this} read {Value} as {name.NullIfWhiteSpace() ?? DataTypeName}");
        }

        public virtual void PostCurrentValue(string name = null)
        {
            Context.Set(Value, name.NullIfWhiteSpace() ?? DataTypeName);
            //Console.WriteLine($"***** {this} posted {Value} as {name.NullIfWhiteSpace() ?? DataTypeName}");
        }

        public virtual void PostValue(string text, string name = null)
        {
            SetValue(text);
            PostCurrentValue(name);
        }

        public abstract void CompareTo(ITypeProcessor other, CompareOp compareOp);

        private int? _clipLength;
        protected int ClipLength => (int)(_clipLength ?? (_clipLength = Context.GetClipLength()));

        protected virtual IComparer Comparer => Context.GetComparer(DataType) ?? Comparer<T>.Default;

        protected virtual void ClearValueCore() { }
        protected virtual void UpdateValueCore(object value) { }
        protected abstract TypeProcessor<T> CloneCore();
        protected abstract T ParseCore(string text);

        protected virtual bool TryParse(string text, out T value)
        {
            try
            {
                Parse(text);
                value = (T)Value;
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }

        protected virtual T ReadFromContextCore(string name = null)
            => Context.GetEx<T>(name.NullIfWhiteSpace() ?? DataTypeName);

        protected void ThrowCompareOpNotSupported(CompareOp compareOp)
            => throw new Exception($"Compare operation '{compareOp}' is not supported for type: {DataTypeName}.");

        protected void ThrowCannotParseEmptyString()
            => throw new Exception($"Cannot parse an empty string as {DataTypeName}.");

        protected void ClearValue()
        {
            Value = null;
            ClearValueCore();
        }

        protected void UpdateValue(object value)
        {
            Value = value;
            UpdateValueCore(value);
        }
    }
}
