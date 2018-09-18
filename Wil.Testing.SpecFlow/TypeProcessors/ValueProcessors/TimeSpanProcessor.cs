using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class TimeSpanProcessor : ValueProcessor<TimeSpan>
    {
        public TimeSpanProcessor(SpecFlowContext context)
            : base(context, $"{nameof(TimeSpanProcessor)}", "timespan", "timespans")
        {
        }

        protected override TimeSpan ParseCore(string text) => TimeSpan.Parse(text);
        protected override bool TryParse(string text, out TimeSpan value) => TimeSpan.TryParse(text, out value);
    }
}
