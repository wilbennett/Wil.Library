using System;

namespace Wil.Core.Interfaces
{
    public struct Rate : IEquatable<Rate>
    {
        /// <summary>Initializes a new instance of the <see cref="Rate"/> struct.</summary>
        /// <param name="count">The maximum number of items allowed.</param>
        /// <param name="period">The time period used to constrain items.</param>
        public Rate(double count, Duration period)
        {
            Count = count;
            Period = period;
        }

        /// <summary>Gets the maximum number of items allowed.</summary>
        /// <returns>The maximum number of items allowed.</returns>
        public double Count { get; }
        /// <summary>Gets the time period used to constrain items.</summary>
        /// <returns>The time period used to constrain items.</returns>
        public Duration Period { get; }

        public static string CountFormatString { get; set; } = "#,##0.##";
        public static string PeriodSeparator { get; set; } = " per ";
        public static string MillisecondString { get; set; } = "ms";
        public static string SecondString { get; set; } = "sec";
        public static string MinuteString { get; set; } = "min";
        public static string HourString { get; set; } = "hour";
        public static string DayString { get; set; } = "day";

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Rate rate)
                return Equals(rate);

            return base.Equals(obj);
        }

        /// <summary>Implements the == operator.</summary>
        /// <param name="first">The first item to compare.</param>
        /// <param name="second">The second item to compare.</param>
        /// <returns><see langword="true"/> if the items are equal, <see langword="false"/> otherwise.</returns>
        public static bool operator ==(Rate first, Rate second) => first.Equals(second);

        /// <summary>Implements the != operator.</summary>
        /// <param name="first">The first item to compare.</param>
        /// <param name="second">The second item to compare.</param>
        /// <returns><see langword="true"/> if the items are not equal, <see langword="false"/> otherwise.</returns>
        public static bool operator !=(Rate first, Rate second) => !(first == second);

        /// <summary>Determines if this instance is equal to the specified instance.</summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns><see langword="true" /> if instances are equal, <see langword="false" /> otherwise.</returns>
        public bool Equals(Rate other) => Count.Equals(other.Count) && Period.Equals(other.Period);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 47;
                hashCode = (hashCode * 53) ^ Count.GetHashCode();
                hashCode = (hashCode * 53) ^ Period.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            string periodString;

            if (Period == _oneSecond) periodString = SecondString;
            else if (Period == _oneMinute) periodString = MinuteString;
            else if (Period == _oneHour) periodString = HourString;
            else if (Period == _oneDay) periodString = DayString;
            else periodString = Period.Value.ToString();

            return $"{Count.ToString(CountFormatString)}{PeriodSeparator}{periodString}";
        }

        private static readonly TimeSpan _oneSecond = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan _oneMinute = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan _oneHour = TimeSpan.FromHours(1);
        private static readonly TimeSpan _oneDay = TimeSpan.FromDays(1);
    }
}
