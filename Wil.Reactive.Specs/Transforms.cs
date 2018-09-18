using System;
using TechTalk.SpecFlow;
using Wil.Core.Interfaces;

namespace Wil.Reactive.Specs
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation(@"([\d\.]+) milliseconds?")]
        public Duration DurationMillisecondsTransform(double milliseconds) => new Duration(milliseconds);

        [StepArgumentTransformation(@"([\d\.]+) seconds?")]
        public Duration DurationSecondsTransform(double seconds) => new Duration(TimeSpan.FromSeconds(seconds));
    }
}
