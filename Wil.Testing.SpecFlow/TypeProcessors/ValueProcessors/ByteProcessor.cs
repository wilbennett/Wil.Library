using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ByteProcessor : ValueProcessor<byte>
    {
        public ByteProcessor(SpecFlowContext context)
            : base(context, $"{nameof(ByteProcessor)}", "byte", "bytes")
        {
        }

        protected override byte ParseCore(string text) => byte.Parse(text);
        protected override bool TryParse(string text, out byte value) => byte.TryParse(text, out value);
    }
}
