using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class UIntProcessor : ValueProcessor<uint>
    {
        public UIntProcessor(SpecFlowContext context)
            : base(context, $"{nameof(UIntProcessor)}", "uint", "uints", "UInt32", "UInt32s")
        {
        }

        protected override uint ParseCore(string text) => uint.Parse(text);
        protected override bool TryParse(string text, out uint value) => uint.TryParse(text, out value);
    }
}
