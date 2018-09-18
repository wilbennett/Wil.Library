using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public interface ITypeProcessor
    {
        SpecFlowContext Context { get; }
        Type DataType { get; }
        string DataTypeName { get; }
        string FriendlyTypeName { get; }
        object Value { get; }

        ITypeProcessor Clone();
        bool CanParse(string text);
        object Parse(string text);
        void SetValue(string text);
        void SetValue(object value);
        void ReadFromContext(string name = null);
        void PostCurrentValue(string name = null);
        void PostValue(string text, string name = null);
        void CompareTo(ITypeProcessor other, CompareOp compareOp);
    }
}
