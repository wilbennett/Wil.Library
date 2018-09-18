using System;
using System.Collections.Generic;
using System.Linq;

namespace Wil.Core
{
    public static class MathUtils
    {
        #region Doubles
        public const double DegreeFactor = 180 / Math.PI;
        public static readonly double Epsilon = 0.000000001;

        //public static bool IsEqualTo(double value1, double value2, int units)
        //{
        //    long lValue1 = BitConverter.DoubleToInt64Bits(value1);
        //    long lValue2 = BitConverter.DoubleToInt64Bits(value2);

        //    // If the signs are different, return false except for +0 and -0. 
        //    if ((lValue1 >> 63) != (lValue2 >> 63))
        //        return value1 == value2;

        //    long diff = Math.Abs(lValue1 - lValue2);
        //    return diff <= (long)units;
        //}

        public static bool IsEqualTo(this double value1, double value2, double epsilon)
            => Math.Abs(value1 - value2) < epsilon;

        public static bool IsEqualTo(this double value1, double value2) => IsEqualTo(value1, value2, Epsilon);

        public static bool IsNotEqualTo(this double value1, double value2, double epsilon)
            => !IsEqualTo(value1, value2, epsilon);

        public static bool IsNotEqualTo(this double value1, double value2) => IsNotEqualTo(value1, value2, Epsilon);

        public static bool IsGreaterOrEqualTo(this double value1, double value2, double epsilon)
            => value1 > value2 || IsEqualTo(value1, value2, epsilon);

        public static bool IsGreaterOrEqualTo(this double value1, double value2)
            => IsGreaterOrEqualTo(value1, value2, Epsilon);

        public static bool IsLessOrEqualTo(this double value1, double value2, double epsilon)
            => value1 < value2 || IsEqualTo(value1, value2, epsilon);

        public static bool IsLessOrEqualTo(this double value1, double value2)
            => IsLessOrEqualTo(value1, value2, Epsilon);

        public static bool IsGreaterThan(this double value1, double value2, double epsilon)
            => (value1 - value2) > epsilon;

        public static bool IsGreaterThan(this double value1, double value2)
            => IsGreaterThan(value1, value2, Epsilon);

        public static bool IsLessThan(this double value1, double value2, double epsilon)
            => (value2 - value1) > epsilon;

        public static bool IsLessThan(this double value1, double value2) => IsLessThan(value1, value2, Epsilon);

        public static bool IsBetween(this double value, double low, double high)
            => value.IsGreaterOrEqualTo(low) && value.IsLessOrEqualTo(high);

        public static double RoundToNearest(this double value, double to) => to * Math.Round(value / to);

        public static double Constrain(this double value, double min, double max)
        {
            if (value < min) return min;
            return value > max ? max : value;
        }

        public static double Angle(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3,
            double x4,
            double y4)
        {
            double result = Math.Atan2(y2 - y1, x2 - x1) - Math.Atan2(y4 - y3, x4 - x3);
            result = result * DegreeFactor;
            return Math.Abs(result);
        }

        public static double Angle(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3)
        {
            return Angle(x1, y1, x2, y2, x2, y2, x3, y3);
        }

        public static void CalculateSlopeAndIntercept(
            double min,
            double max,
            double newMin,
            double newMax,
            out double slope,
            out double intercept)
        {
            double run = max - min;

            if (run.IsEqualTo(0)) run = 1;

            slope = (newMax - newMin) / run;
            intercept = newMax - (slope * max);
        }

        public static double StdDev(this IList<double> values)
        {
            double mean = values.Average();
            double diffSum = 0;

            for (int i = 0; i < values.Count; i++)
            {
                double diff = values[i] - mean;
                diffSum += diff * diff;
            }

            double variance = diffSum / values.Count;
            return Math.Sqrt(variance);
        }
        #endregion

        #region Floats
        public const float FloatDegreeFactor = (float)(180 / Math.PI);
        public static readonly float FloatEpsilon = 0.000000001f;

        //public static bool IsEqualTo(float value1, float value2, int units)
        //{
        //    long lValue1 = BitConverter.DoubleToInt64Bits(value1);
        //    long lValue2 = BitConverter.DoubleToInt64Bits(value2);

        //    // If the signs are different, return false except for +0 and -0. 
        //    if ((lValue1 >> 63) != (lValue2 >> 63))
        //        return value1 == value2;

        //    long diff = Math.Abs(lValue1 - lValue2);
        //    return diff <= units;
        //}

        public static bool IsEqualTo(this float value1, float value2, float epsilon)
            => Math.Abs(value1 - value2) < epsilon;

        public static bool IsEqualTo(this float value1, float value2) => IsEqualTo(value1, value2, FloatEpsilon);

        public static bool IsNotEqualTo(this float value1, float value2, float epsilon)
            => !IsEqualTo(value1, value2, epsilon);

        public static bool IsNotEqualTo(this float value1, float value2) => IsNotEqualTo(value1, value2, FloatEpsilon);

        public static bool IsGreaterOrEqualTo(this float value1, float value2, float epsilon)
            => value1 > value2 || IsEqualTo(value1, value2, epsilon);

        public static bool IsGreaterOrEqualTo(this float value1, float value2)
            => IsGreaterOrEqualTo(value1, value2, FloatEpsilon);

        public static bool IsLessOrEqualTo(this float value1, float value2, float epsilon)
            => value1 < value2 || IsEqualTo(value1, value2, epsilon);

        public static bool IsLessOrEqualTo(this float value1, float value2)
            => IsLessOrEqualTo(value1, value2, FloatEpsilon);

        public static bool IsGreaterThan(this float value1, float value2, float epsilon)
            => (value1 - value2) > epsilon;

        public static bool IsGreaterThan(this float value1, float value2) => IsGreaterThan(value1, value2, FloatEpsilon);

        public static bool IsLessThan(this float value1, float value2, float epsilon)
            => (value2 - value1) > epsilon;

        public static bool IsLessThan(this float value1, float value2) => IsLessThan(value1, value2, FloatEpsilon);

        public static bool IsBetween(this float value, float low, float high)
            => value.IsGreaterOrEqualTo(low) && value.IsLessOrEqualTo(high);

        public static float RoundToNearest(this float value, float to) => (float)(to * Math.Round(value / to));

        public static float Constrain(this float value, float min, float max)
        {
            if (value < min) return min;
            return value > max ? max : value;
        }

        public static float Angle(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3,
            float x4,
            float y4)
        {
            float result = (float)(Math.Atan2(y2 - y1, x2 - x1) - Math.Atan2(y4 - y3, x4 - x3));
            result = result * FloatDegreeFactor;
            return Math.Abs(result);
        }

        public static float Angle(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3)
        {
            return Angle(x1, y1, x2, y2, x2, y2, x3, y3);
        }

        public static void CalculateSlopeAndIntercept(
            float min,
            float max,
            float newMin,
            float newMax,
            out float slope,
            out float intercept)
        {
            float run = max - min;

            if (run.IsEqualTo(0)) run = 1;

            slope = (newMax - newMin) / run;
            intercept = newMax - (slope * max);
        }

        public static float StdDev(this IList<float> values)
        {
            float mean = values.Average();
            float diffSum = 0;

            for (int i = 0; i < values.Count; i++)
            {
                float diff = values[i] - mean;
                diffSum += diff * diff;
            }

            double variance = diffSum / values.Count;
            return (float)Math.Sqrt(variance);
        }
        #endregion
    }
}
