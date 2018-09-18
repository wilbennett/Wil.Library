using TechTalk.SpecFlow;
using Wil.Core;

namespace Wil.Testing.SpecFlow
{
    public class CharProcessor : ValueProcessor<char>
    {
        public CharProcessor(SpecFlowContext context)
            : base(context, $"{nameof(CharProcessor)}", "char", "chars")
        {
        }

        protected override char ParseCore(string text) => char.Parse(text.Unescape());
        protected override bool TryParse(string text, out char value) => char.TryParse(text.Unescape(), out value);
    }
}
