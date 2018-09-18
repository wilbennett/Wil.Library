namespace Wil.Core.Interfaces
{
    public interface IScaler
    {
        double MaxDataValue { get; }
        double MinDataValue { get; }
        double MaxScaleValue { get; }
        double MinScaleValue { get; }

        void GetScaledValue(string value, out double result);
        void GetScaledValue(string value, out float result);
        void GetScaledValue(object value, out double result);
        void GetScaledValue(object value, out float result);
        void GetUnscaledValue(double scaledValue, out double result);
        void GetUnscaledValue(double scaledValue, out float result);
        void GetUnscaledValue(double scaledValue, out string result);
    }
}