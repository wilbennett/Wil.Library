using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class FloatProcessor : ValueProcessor<float>
    {
        public FloatProcessor(SpecFlowContext context)
            : base(context, $"{nameof(FloatProcessor)}", "float", "floats")
        {
        }

        protected override float ParseCore(string text) => float.Parse(text);
        protected override bool TryParse(string text, out float value) => float.TryParse(text, out value);
    }
}
