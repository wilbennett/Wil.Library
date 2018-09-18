using System;
using Wil.Core.Interfaces;

namespace Wil.Core
{
    public class DoubleScaler : Scaler, IScaler
    {
        public DoubleScaler(double minScaleValue, double maxScaleValue, double minDataValue, double maxDataValue)
            : base(minScaleValue, maxScaleValue, minDataValue, maxDataValue)
        {
        }

        public void GetScaledValue(string value, out double result)
            => result = GetScaledValueCore(double.Parse(value));

        public void GetScaledValue(string value, out float result)
            => result = (float)GetScaledValueCore(double.Parse(value));

        public void GetScaledValue(object value, out double result)
            => result = GetScaledValueCore(Convert.ToDouble(value));

        public void GetScaledValue(object value, out float result)
            => result = (float)GetScaledValueCore(Convert.ToDouble(value));

        public void GetUnscaledValue(double scaledValue, out double result)
            => result = GetUnscaledValue(scaledValue);

        public void GetUnscaledValue(double scaledValue, out float result)
            => result = (float)GetUnscaledValue(scaledValue);

        public void GetUnscaledValue(double scaledValue, out string result)
            => result = GetUnscaledValue(scaledValue).ToString();
    }
}