namespace Wil.Core.Interfaces
{
    public interface IScalerBuilder
    {
        double MinScaleValue { get; }
        double MaxScaleValue { get; }
        double MinDataValue { get; set; }
        double MaxDataValue { get; set; }
        IScaler Scaler { get; }

        void AddDataValue(string value);
        void AddDataValue(object value);
    }
}