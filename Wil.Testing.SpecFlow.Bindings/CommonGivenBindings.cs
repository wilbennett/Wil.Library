using System;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow.Bindings
{
    [Binding]
    public class CommonGivenBindings : BindingsBase
    {
        public CommonGivenBindings(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(scenarioContext, featureContext)
        {
        }

        //[Given(@"(?i)epsilon double '?(.+?)'?")]
        //public void GivenEpsilonDouble(double value) => _scenario.Set(value, "doubleEpsilon");

        //[Given(@"(?i)epsilon float '?(.+?)'?")]
        //public void GivenEpsilonFloat(float value) => _scenario.Set(value, "floatEpsilon");

        [Given(@"(.*) is date time offset (\d+), (\d+), (\d+)")]
        public void GivenIsDateTimeOffset(string name, int year, int month, int day)
            => _scenario.Set(new DateTimeOffset(new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc)), name);
   }
}