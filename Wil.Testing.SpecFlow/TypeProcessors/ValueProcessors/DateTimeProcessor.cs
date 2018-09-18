using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Wil.Testing.SpecFlow
{
    public class DateTimeProcessor : ValueProcessor<DateTime>
    {
        public DateTimeProcessor(SpecFlowContext context)
            : base(context, $"{nameof(DateTimeProcessor)}", "datetime", "datetimes")
        {
        }

        protected override DateTime ParseCore(string text)
        {
            try
            {
                Match match = Regex.Match(
                    text,
                    @"^(?:(?<utc>utc) )?(?<yr>\d{4})[-/](?<mo>\d{2})[-/](?<dy>\d{2})(?: (?<hr>\d{1,2}):(?<mn>\d{1,2}):(?<sc>\d{1,2})(?:\.(?<ms>\d{1,3}))?)?(?: (?<utc>utc))?$");

                if (!match.Success) throw new Exception("Invalid string format.");

                int year = int.Parse(match.Groups["yr"].Value);
                int month = int.Parse(match.Groups["mo"].Value);
                int day = int.Parse(match.Groups["dy"].Value);

                if (string.IsNullOrEmpty(match.Groups["hr"].Value))
                    return new DateTime(year, month, day);

                int hour = int.Parse(match.Groups["hr"].Value);
                int minute = int.Parse(match.Groups["mn"].Value);
                int second = int.Parse(match.Groups["sc"].Value);

                int millisecond
                    = string.IsNullOrEmpty(match.Groups["ms"].Value)
                    ? 0
                    : int.Parse(match.Groups["ms"].Value);

                DateTimeKind kind
                    = string.IsNullOrEmpty(match.Groups["utc"].Value)
                    ? DateTimeKind.Local
                    : DateTimeKind.Utc;

                return new DateTime(year, month, day, hour, minute, second, millisecond, kind);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot convert '{text}' to a DateTime.", ex);
            }
        }
    }
}
