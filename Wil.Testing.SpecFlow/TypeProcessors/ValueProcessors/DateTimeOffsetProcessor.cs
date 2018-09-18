using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class DateTimeOffsetProcessor : ValueProcessor<DateTimeOffset>
    {
        public DateTimeOffsetProcessor(SpecFlowContext context)
            : base(context, $"{nameof(DateTimeOffsetProcessor)}", "datetimeoffset", "datetimeoffsets")
        {
        }

        protected override DateTimeOffset ParseCore(string text)
        {
            try
            {
                var match = Regex.Match(
                    text,
                    @"^(?<yr>\d{4})[-/](?<mo>\d{2})[-/](?<dy>\d{2})(?: (?<hr>\d{1,2}):(?<mn>\d{1,2}):(?<sc>\d{1,2})(?:\.(?<ms>\d{1,3}))?)?(?: (?<ofs>-?\d{1,2}:\d{1,2}))$");

                if (!match.Success) throw new Exception("Invalid string format.");

                int year = int.Parse(match.Groups["yr"].Value);
                int month = int.Parse(match.Groups["mo"].Value);
                int day = int.Parse(match.Groups["dy"].Value);

                var ofs = TimeSpan.Parse(match.Groups["ofs"].Value);
                if (string.IsNullOrEmpty(match.Groups["hr"].Value))
                    return new DateTimeOffset(year, month, day, 0, 0, 0, ofs);

                int hour = int.Parse(match.Groups["hr"].Value);
                int minute = int.Parse(match.Groups["mn"].Value);
                int second = int.Parse(match.Groups["sc"].Value);

                int millisecond
                    = string.IsNullOrEmpty(match.Groups["ms"].Value)
                    ? 0
                    : int.Parse(match.Groups["ms"].Value);

                return new DateTimeOffset(year, month, day, hour, minute, second, millisecond, ofs);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot convert '{text}' to a DateTimeOffset.", ex);
            }
        }
    }
}
