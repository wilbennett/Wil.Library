using System;

namespace Wil.Core
{
    public static class DateTimeUtils
    {
        public static DateTime TruncToMinute(this DateTime instance)
            => new DateTime(instance.Year, instance.Month, instance.Day, instance.Hour, instance.Minute, 0, instance.Kind);

        public static DateTime ReplaceMinute(this DateTime instance, int minute)
        {
            return new DateTime(
                instance.Year,
                instance.Month,
                instance.Day,
                instance.Hour,
                minute,
                instance.Second,
                instance.Millisecond,
                instance.Kind);
        }
    }
}