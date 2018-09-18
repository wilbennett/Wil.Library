using System;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;

namespace Wil.Testing.SpecFlow
{
    public class DurationProcessor : ValueProcessor<Duration>
    {
        public DurationProcessor(SpecFlowContext context)
            : base(context, $"{nameof(DurationProcessor)}", "duration", "durations")
        {
        }

        protected override Duration ParseCore(string text) => TimeSpan.Parse(text);

        protected override bool TryParse(string text, out Duration value)
        {
            bool result = TimeSpan.TryParse(text, out TimeSpan ts);
            value = ts;
            return result;
        }
    }
}
