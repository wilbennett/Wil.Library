using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public class StringProcessor : ValueProcessor<string>
    {
        public StringProcessor(SpecFlowContext context)
            : base(context, $"{nameof(StringProcessor)}", "string", "strings")
        {
        }

        public override bool CanParseEmptyString => true;

        protected override bool TryParse(string text, out string value)
        {
            value = text.Unescape();
            return true;
        }

        protected override string ParseCore(string text) => text.Unescape();
    }
}
