using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class DecimalProcessor : ValueProcessor<decimal>
    {
        public DecimalProcessor(SpecFlowContext context)
            : base(context, $"{nameof(DecimalProcessor)}", "decimal", "decimals")
        {
        }

        protected override decimal ParseCore(string text) => decimal.Parse(text);
        protected override bool TryParse(string text, out decimal value) => decimal.TryParse(text, out value);
    }
}
