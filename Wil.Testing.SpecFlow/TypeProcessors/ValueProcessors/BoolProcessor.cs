using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class BoolProcessor : ValueProcessor<bool>
    {
        public BoolProcessor(SpecFlowContext context)
            : base(context, $"{nameof(BoolProcessor)}", "bool", "bools", "boolean", "booleans")
        {
        }

        protected override bool ParseCore(string text) => bool.Parse(text);
        protected override bool TryParse(string text, out bool value) => bool.TryParse(text, out value);
    }
}
