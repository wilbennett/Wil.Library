using System.Collections.ObjectModel;
using Wil.Core.Interfaces;

namespace Wil.Core
{
    public class StringScalerBuilder : ScalerBuilder, IScalerBuilder
    {
        public StringScalerBuilder(double minScaleValue, double maxScaleValue)
            : base(minScaleValue, maxScaleValue)
        {
        }

        public IScaler Scaler
            => new StringScaler(MinScaleValue, MaxScaleValue, MinDataValue, MaxDataValue, _values);

        public void AddDataValue(string value)
        {
            if (_values.Contains(value)) return;

            AddDataValueCore(_values.Count);
            _values.Add(value);
        }

        public void AddDataValue(object value) => AddDataValue(value.ToString());

        private readonly KeyedStringCollection _values = new KeyedStringCollection();
    }
}