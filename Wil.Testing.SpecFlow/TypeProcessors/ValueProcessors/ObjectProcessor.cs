using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class ObjectProcessor : ValueProcessor<object>
    {
        public ObjectProcessor(SpecFlowContext context)
            : base(context, $"{nameof(ObjectProcessor)}", "object")
        {
        }

        protected override object ParseCore(string text) => text;
    }
}
