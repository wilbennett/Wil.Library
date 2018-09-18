using System.Collections.Generic;
using System.Linq;
using Wil.Core.Interfaces;

namespace Wil.Core
{
    public class StringScaler : Scaler, IScaler
    {
        public StringScaler(
            double minScaleValue,
            double maxScaleValue,
            double minDataValue,
            double maxDataValue,
            IEnumerable<string> values)
            : base(minScaleValue, maxScaleValue, minDataValue, maxDataValue)
        {
            _values = values.ToList();
        }

        public void GetScaledValue(string value, out double result)
            => result = GetScaledValueCore(_values.IndexOf(value));

        public void GetScaledValue(string value, out float result)
            => result = (float)GetScaledValueCore(_values.IndexOf(value));

        public void GetScaledValue(object value, out double result) => GetScaledValue(value.ToString(), out result);
        public void GetScaledValue(object value, out float result) => GetScaledValue(value.ToString(), out result);

        public void GetUnscaledValue(double scaledValue, out double result)
            => result = GetUnscaledValue(scaledValue);

        public void GetUnscaledValue(double scaledValue, out float result)
            => result = (float)GetUnscaledValue(scaledValue);

        public void GetUnscaledValue(double scaledValue, out string result)
            => result = _values[(int)GetUnscaledValue(scaledValue)];

        private readonly List<string> _values;
    }
}