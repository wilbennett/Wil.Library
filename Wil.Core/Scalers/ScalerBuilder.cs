using System;

namespace Wil.Core
{
    public abstract class ScalerBuilder
    {
        protected ScalerBuilder(double minScaleValue, double maxScaleValue)
        {
            MinScaleValue = minScaleValue;
            MaxScaleValue = maxScaleValue;

            MinDataValue = double.MaxValue;
            MaxDataValue = double.MinValue;
        }

        public double MinScaleValue { get; }
        public double MaxScaleValue { get; }
        public double MinDataValue { get; set; }
        public double MaxDataValue { get; set; }

        protected double _slope;
        protected double _intercept;
        protected double _reverseSlope;
        protected double _reverseIntercept;

        protected void AddDataValueCore(double value)
        {
            MinDataValue = Math.Min(value, MinDataValue);
            MaxDataValue = Math.Max(value, MaxDataValue);
        }
    }
}