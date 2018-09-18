using System;
using Wil.Core.Interfaces;

namespace Wil.Core
{
    public class DoubleScalerBuilder : ScalerBuilder, IScalerBuilder
    {
        public DoubleScalerBuilder(double minScaleValue, double maxScaleValue)
            : base(minScaleValue, maxScaleValue)
        {
        }

        public IScaler Scaler => new DoubleScaler(MinScaleValue, MaxScaleValue, MinDataValue, MaxDataValue);

        public void AddDataValue(string value) => AddDataValueCore(double.Parse(value));
        public void AddDataValue(object value) => AddDataValueCore((double)Convert.ToDouble(value));
    }
}