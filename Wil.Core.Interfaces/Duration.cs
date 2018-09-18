using System;
using System.Threading;

namespace Wil.Core.Interfaces
{
    public struct Duration : IComparable<Duration>
    {
        #region Constructors/Finalizer
        /// <summary>Initializes a new instance of the <see cref="Duration"/> class.</summary>
        public Duration(TimeSpan timeout)
        {
            _value = timeout;
        }

        /// <summary>Initializes a new instance of the <see cref="Duration"/> structure.</summary>
        /// <param name="millisecondsTimeout">The timeout in milliseconds.</param>
        public Duration(int millisecondsTimeout)
            : this(TimeSpan.FromMilliseconds(millisecondsTimeout))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Duration"/> structure.</summary>
        /// <param name="millisecondsTimeout">The timeout in milliseconds.</param>
        public Duration(double millisecondsTimeout)
            : this(TimeSpan.FromMilliseconds(millisecondsTimeout))
        {
        }
        #endregion

        /// <summary>Represents an empty duration.</summary>
        public static readonly Duration Zero = 0;
        /// <summary>Represents an infinite duration.</summary>
        public static readonly Duration Infinite = Timeout.Infinite;

        private TimeSpan _value;
        /// <summary>The timeout.</summary>
        public TimeSpan Value => _value;

        #region Ancestor Overrides
        /// <summary>Determines whether the specified <see cref="System.Object"/> is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise,
        /// <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null: return false;
                case Duration d: return Value.Equals(d.Value);
                case TimeSpan ts: return Value.Equals(ts);
                case double ms: return Value.TotalMilliseconds.Equals(ms);
                case int ms: return ms.Equals((int)Value.TotalMilliseconds);
                default: return false;
            }
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash
        /// table.
        /// </returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => Value.ToString();

        #region Operator Overloads
        #region Conversion
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.TimeSpan"/> to <see cref="Wil.Core.Duration"/>.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Duration(TimeSpan period) => new Duration(period);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Duration"/> to <see cref="System.TimeSpan"/>.
        /// </summary>
        /// <param name="period">The period value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TimeSpan(Duration period) => period.Value;

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Wil.Core.Duration"/>.
        /// </summary>
        /// <param name="milliseconds">The period in milliseconds.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Duration(int milliseconds) => new Duration(milliseconds);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Wil.Core.Duration"/> to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="period">The period value.</param>
        /// <returns>The period in milliseconds.</returns>
        public static implicit operator int(Duration period) => (int)period.Value.TotalMilliseconds;

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Duration"/>.
        /// </summary>
        /// <param name="ticks">The period in ticks.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Duration(long ticks) => new Duration(TimeSpan.FromTicks(ticks));

        /// <summary>
        /// Performs an implicit conversion from <see cref="Duration"/> to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="period">The period value.</param>
        /// <returns>The period in ticks.</returns>
        public static implicit operator long(Duration period) => period.Value.Ticks;

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Double"/> to <see cref="Wil.Core.Duration"/>.
        /// </summary>
        /// <param name="milliseconds">The period in milliseconds.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Duration(double milliseconds) => new Duration(milliseconds);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Wil.Core.Duration"/> to <see cref="System.Double"/>.
        /// </summary>
        /// <param name="period">The period value.</param>
        /// <returns>The period in milliseconds.</returns>
        public static implicit operator double(Duration period) => period.Value.TotalMilliseconds;
        #endregion

        #region Addition
        /// <summary>Implements the operator +.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator +(Duration value1, Duration value2)
        {
            return value1.Value + value2.Value;
        }

        /// <summary>Implements the operator +.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator +(Duration value1, TimeSpan value2)
        {
            return value1.Value + value2;
        }

        /// <summary>Implements the operator +.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator +(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds + value2;
        }

        /// <summary>Implements the operator +.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator +(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds + value2;
        }
        #endregion

        #region Subtraction
        /// <summary>Implements the operator -.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator -(Duration value1, Duration value2)
        {
            return value1.Value - value2.Value;
        }

        /// <summary>Implements the operator -.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator -(Duration value1, TimeSpan value2)
        {
            return value1.Value - value2;
        }

        /// <summary>Implements the operator -.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator -(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds - value2;
        }

        /// <summary>Implements the operator -.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static Duration operator -(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds - value2;
        }
        #endregion

        #region Equal
        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Duration value1, Duration value2)
        {
            return value1.Value == value2.Value;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Duration value1, TimeSpan value2)
        {
            return value1.Value == value2;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds == value2;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds == value2;
        }
        #endregion

        #region Not Equal
        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Duration value1, Duration value2)
        {
            return value1.Value != value2.Value;
        }

        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Duration value1, TimeSpan value2)
        {
            return value1.Value != value2;
        }

        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds != value2;
        }

        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds != value2;
        }
        #endregion

        #region Greater Than
        /// <summary>Implements the operator >.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Duration value1, Duration value2)
        {
            return value1.Value > value2.Value;
        }

        /// <summary>Implements the operator >.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Duration value1, TimeSpan value2)
        {
            return value1.Value > value2;
        }

        /// <summary>Implements the operator >.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(TimeSpan value1, Duration value2)
        {
            return value1 > value2.Value;
        }

        /// <summary>Implements the operator >.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds > value2;
        }

        /// <summary>Implements the operator >.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds > value2;
        }
        #endregion

        #region Greater Or Equal
        /// <summary>Implements the operator >=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Duration value1, Duration value2)
        {
            return value1.Value >= value2.Value;
        }

        /// <summary>Implements the operator >=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Duration value1, TimeSpan value2)
        {
            return value1.Value >= value2;
        }

        /// <summary>Implements the operator >=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds >= value2;
        }

        /// <summary>Implements the operator >=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds >= value2;
        }
        #endregion

        #region Less Than
        /// <summary>Implements the operator &lt;.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Duration value1, Duration value2)
        {
            return value1.Value < value2.Value;
        }

        /// <summary>Implements the operator &lt;.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Duration value1, TimeSpan value2)
        {
            return value1.Value < value2;
        }

        /// <summary>Implements the operator &lt;.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(TimeSpan value1, Duration value2)
        {
            return value1 < value2.Value;
        }

        /// <summary>Implements the operator &lt;.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds < value2;
        }

        /// <summary>Implements the operator &lt;.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds < value2;
        }
        #endregion

        #region Less Or Equal
        /// <summary>Implements the operator &lt;=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Duration value1, Duration value2)
        {
            return value1.Value <= value2.Value;
        }

        /// <summary>Implements the operator &lt;=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Duration value1, TimeSpan value2)
        {
            return value1.Value <= value2;
        }

        /// <summary>Implements the operator &lt;=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Duration value1, int value2)
        {
            return value1.Value.TotalMilliseconds <= value2;
        }

        /// <summary>Implements the operator &lt;=.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The value to compare to.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Duration value1, double value2)
        {
            return value1.Value.TotalMilliseconds <= value2;
        }
        #endregion
        #endregion
        #endregion

        #region IComparable<Duration> Members
        /// <summary>Compares this instance to the specified instance.</summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns>
        /// A negative value if this instance is less than the specified value, zero if they are equal; otherwise,
        /// a positive value.
        /// </returns>
        public int CompareTo(Duration other)
        {
            return Value.CompareTo(other.Value);
        }
        #endregion
    }
}
