using System;

namespace Wil.Core.Interfaces.Extensions
{
    public static class DurationExtensions
    {
        public static Duration Milliseconds(this int value) => new Duration(value);
        public static Duration Milliseconds(this double value) => new Duration(value);
        public static Duration Second(this int value) => TimeSpan.FromSeconds(value);
        public static Duration Second(this double value) => TimeSpan.FromSeconds(value);
        public static Duration Seconds(this int value) => TimeSpan.FromSeconds(value);
        public static Duration Seconds(this double value) => TimeSpan.FromSeconds(value);
        public static Duration Minute(this int value) => TimeSpan.FromMinutes(value);
        public static Duration Minute(this double value) => TimeSpan.FromMinutes(value);
        public static Duration Minutes(this int value) => TimeSpan.FromMinutes(value);
        public static Duration Minutes(this double value) => TimeSpan.FromMinutes(value);
        public static Duration Hour(this int value) => TimeSpan.FromHours(value);
        public static Duration Hour(this double value) => TimeSpan.FromHours(value);
        public static Duration Hours(this int value) => TimeSpan.FromHours(value);
        public static Duration Hours(this double value) => TimeSpan.FromHours(value);
        public static Duration Day(this int value) => TimeSpan.FromDays(value);
        public static Duration Day(this double value) => TimeSpan.FromDays(value);
        public static Duration Days(this int value) => TimeSpan.FromDays(value);
        public static Duration Days(this double value) => TimeSpan.FromDays(value);
        public static Duration Ticks(this int value) => TimeSpan.FromTicks(value);
        public static Duration Ticks(this long value) => TimeSpan.FromTicks(value);
    }
}
