using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ShortProcessor : ValueProcessor<short>
    {
        public ShortProcessor(SpecFlowContext context)
            : base(context, $"{nameof(ShortProcessor)}", "short", "shorts", "Int16", "int16s")
        {
        }

        protected override short ParseCore(string text) => short.Parse(text);
        protected override bool TryParse(string text, out short value) => short.TryParse(text, out value);
    }
}
