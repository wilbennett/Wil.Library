using Wil.Core.Interfaces;

namespace Wil.Reactive.Interfaces
{
    public struct RateEvent<T>
    {
        public RateEvent(double count, Duration period)
        {
            Count = count;
            Period = period;

            Value = default(T);
            HasValue = false;
            _rate = null;
        }

        public RateEvent(T value, double count, Duration period)
            : this(count, period)
        {
            Value = value;

            HasValue = true;
        }

        public RateEvent(Rate rate)
            : this(rate.Count, rate.Period)
        {
            _rate = rate;

            Value = default(T);
            HasValue = false;
            _rate = null;
        }

        public RateEvent(T value, Rate rate)
            : this(rate)
        {
            Value = value;

            HasValue = true;
        }

        public T Value { get; }
        public bool HasValue { get; }
        public double Count { get; }
        public Duration Period { get; }
        private Rate? _rate;
        public Rate Rate => _rate ?? (Rate)(_rate = new Rate(Count, Period));
        public override string ToString() => $"{Value} - {Rate}";
    }
}
