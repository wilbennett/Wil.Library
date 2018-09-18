using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class DoubleProcessor : ValueProcessor<double>
    {
        public DoubleProcessor(SpecFlowContext context)
            : base(context, $"{nameof(DoubleProcessor)}", "double", "doubles")
        {
        }

        protected override double ParseCore(string text) => double.Parse(text);
        protected override bool TryParse(string text, out double value) => double.TryParse(text, out value);
    }
}
