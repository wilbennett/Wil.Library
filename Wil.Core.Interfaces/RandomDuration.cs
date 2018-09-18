using System;

namespace Wil.Core.Interfaces
{
    public struct RandomDuration
    {
        public RandomDuration(Duration min, Duration max)
        {
            Min = Math.Min(min.Value.TotalMilliseconds, max.Value.TotalMilliseconds);
            Max = Math.Max(min.Value.TotalMilliseconds, max.Value.TotalMilliseconds);

            _minMilliseconds = Min.Value.TotalMilliseconds;
            double maxMilliseconds = Max.Value.TotalMilliseconds;
            _range = maxMilliseconds - _minMilliseconds;
            _rand = new Random();
        }

        public Duration Min { get; }
        public Duration Max { get; }

        public Duration Next() => _rand.NextDouble() * _range + _minMilliseconds;

        private readonly double _minMilliseconds;
        private readonly double _range;
        private readonly Random _rand;
    }
}
