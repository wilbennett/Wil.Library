using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ULongProcessor : ValueProcessor<ulong>
    {
        public ULongProcessor(SpecFlowContext context)
            : base(context, $"{nameof(ULongProcessor)}", "uint64", "uint64s", "ulong", "ulongs")
        {
        }

        protected override ulong ParseCore(string text) => ulong.Parse(text);
        protected override bool TryParse(string text, out ulong value) => ulong.TryParse(text, out value);
    }
}
