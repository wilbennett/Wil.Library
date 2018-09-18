using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class IntProcessor : ValueProcessor<int>
    {
        public IntProcessor(SpecFlowContext context)
            : base(context, $"{nameof(IntProcessor)}", "int", "ints", "Int32", "Int32s", "integer", "integers")
        {
        }

        protected override int ParseCore(string text) => int.Parse(text);
        protected override bool TryParse(string text, out int value) => int.TryParse(text, out value);
    }
}
