namespace Wil.Core
{
    public abstract class Scaler
    {
        protected Scaler(
            double minScaleValue, 
            double maxScaleValue, 
            double minDataValue, 
            double maxDataValue)
        {
            MinScaleValue = minScaleValue;
            MaxScaleValue = maxScaleValue;

            MinDataValue = minDataValue;
            MaxDataValue = maxDataValue;

            CalculateSlopesAndIntercepts(
                MinDataValue,
                MaxDataValue,
                MinScaleValue,
                MaxScaleValue,
                out _slope,
                out _intercept,
                out _reverseSlope,
                out _reverseIntercept);
        }

        public double MinScaleValue { get; }
        public double MaxScaleValue { get; }
        public double MinDataValue { get; }
        public double MaxDataValue { get; }

        protected readonly double _slope;
        protected readonly double _intercept;
        protected readonly double _reverseSlope;
        protected readonly double _reverseIntercept;

        protected double GetScaledValueCore(double value) => value * _slope + _intercept;
        protected double GetUnscaledValue(double scaledValue) => scaledValue * _reverseSlope + _reverseIntercept;

        private static void CalculateSlopesAndIntercepts(
            double minDataValue,
            double maxDataValue,
            double minScaleValue,
            double maxScaleValue,
            out double slope,
            out double intercept,
            out double reverseSlope,
            out double reverseIntercept
            )
        {
            MathUtils.CalculateSlopeAndIntercept(
                minDataValue,
                maxDataValue,
                minScaleValue,
                maxScaleValue,
                out slope,
                out intercept);

            MathUtils.CalculateSlopeAndIntercept(
                minScaleValue,
                maxScaleValue,
                minDataValue,
                maxDataValue,
                out reverseSlope,
                out reverseIntercept);
        }
    }
}