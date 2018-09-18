using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class UShortProcessor : ValueProcessor<ushort>
    {
        public UShortProcessor(SpecFlowContext context)
            : base(context, $"{nameof(UShortProcessor)}", "ushort", "ushorts", "UInt16", "Uint16s")
        {
        }

        protected override ushort ParseCore(string text) => ushort.Parse(text);
        protected override bool TryParse(string text, out ushort value) => ushort.TryParse(text, out value);
    }
}
