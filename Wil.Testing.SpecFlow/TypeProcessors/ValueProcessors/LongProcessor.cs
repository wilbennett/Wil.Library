using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class LongProcessor : ValueProcessor<long>
    {
        public LongProcessor(SpecFlowContext context)
            : base(context, $"{nameof(LongProcessor)}", "int64", "int64s", "long", "longs")
        {
        }

        protected override long ParseCore(string text) => long.Parse(text);
        protected override bool TryParse(string text, out long value) => long.TryParse(text, out value);
    }
}
