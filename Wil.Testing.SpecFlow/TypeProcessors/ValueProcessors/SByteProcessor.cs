using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class SByteProcessor : ValueProcessor<sbyte>
    {
        public SByteProcessor(SpecFlowContext context)
            : base(context, $"{nameof(SByteProcessor)}", "sbyte", "sbytes")
        {
        }

        protected override sbyte ParseCore(string text) => sbyte.Parse(text);
        protected override bool TryParse(string text, out sbyte value) => sbyte.TryParse(text, out value);
    }
}
