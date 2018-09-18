#if !DEBUG
#define RELEASE
#endif

#if PUBLIC_CONTRACTS || PUBLIC_CHECKS || PRIVATE_CONTRACTS || PRIVATE_CHECKS
#define ENABLED
#endif

#if DEBUG && ENABLED
#define ASSERTIONS_ENABLED
#endif

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Wil.Contracts.specs
{
    public class TestTraceListener : TraceListener
    {
        public TestTraceListener(ScenarioContext scenario) => _scenario = scenario;

        public override void Write(string message)
        {
#if ASSERTIONS_ENABLED
            if (!string.IsNullOrEmpty(message))
                message = Regex.Replace(message, @"^Fail:\s*", "", RegexOptions.IgnoreCase);

            _scenario.Set(new Exception(message), "exception");
            _scenario.Set(message, "exceptionMessage");
#endif
        }

        public override void WriteLine(string message)
        {
            Write(message);
        }

        private readonly ScenarioContext _scenario;
    }
}

