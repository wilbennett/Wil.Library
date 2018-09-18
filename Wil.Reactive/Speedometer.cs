using System;
using System.Reactive.Concurrency;
using Wil.Core;
using Wil.Core.Interfaces;
using Wil.Core.Interfaces.Extensions;
using Wil.Reactive.Interfaces;

namespace Wil.Reactive
{
    // TODO: Refactor to use Exponential Moving Average
    public class Speedometer : ISpeedometer
    {
        public Speedometer(Duration period, Duration refreshPeriod, IScheduler scheduler = null)
        {
            Period = period;
            RefreshPeriod = refreshPeriod;
            Scheduler = scheduler ?? System.Reactive.Concurrency.Scheduler.Default;

            _stopWatch = Scheduler.StartStopwatch();

            Start();
        }

        public Speedometer(Duration period, IScheduler scheduler = null)
            : this(period, 1.Second(), scheduler)
        {
        }

        private Duration _period;
        public Duration Period
        {
            get => _period;
            set
            {
                _period = value;
                _sampleSeconds = _period.Value.TotalSeconds;
            }
        }

        private Duration _refreshPeriod;
        public Duration RefreshPeriod
        {
            get => _refreshPeriod;
            set
            {
                _refreshPeriod = value;
                _refreshSeconds = RefreshPeriod.Value.TotalSeconds;
            }
        }

        public IScheduler Scheduler { get; }
        public double Count { get; private set; }
        public bool Sampled { get; private set; }
        public string CountFormatString { get; set; } = "#,##0.##";
        public string PeriodSeparator { get; set; } = " per ";

        private Rate? _rate;
        public Rate Rate
        {
            get
            {
                if (_rate == null)
                    _rate = new Rate(Count, Period);

                return _rate.Value;
            }
        }

        private string _periodString;
        public string PeriodString
        {
            get
            {
                if (_periodString == null)
                {
                    if (Period == _oneSecond) _periodString = "sec";
                    else if (Period == _oneMinute) _periodString = "min";
                    else if (Period == _oneHour) _periodString = "hour";
                    else if (Period == _oneDay) _periodString = "day";
                    else _periodString = Period.Value.ToString();
                }

                return _periodString;
            }

            set => _periodString = value;
        }

        public void Start() => Reset();

        public bool Update(int count = 1, bool force = false)
        {
            if (UpdateCore(count)) return true;
            if (!force) return false;

            Sample(_sampleSeconds / ElapsedSeconds(), force);
            return true;
        }

        public override string ToString()
            => $"{Count.ToString(CountFormatString)}{PeriodSeparator}{PeriodString}{(Sampled ? "" : "*")}";

        private static readonly TimeSpan _oneSecond = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan _oneMinute = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan _oneHour = TimeSpan.FromHours(1);
        private static readonly TimeSpan _oneDay = TimeSpan.FromDays(1);

        private readonly IStopwatch _stopWatch;
        private int _currentItemCount;
        private double _currentCount;
        private TimeSpan _periodStart;
        private double _currentElapsedSeconds;
        private double _sampleSeconds;
        private double _refreshSeconds;

        private void Reset()
        {
            _currentItemCount = 0;
            _currentCount = 0;
            Count = 0;
            Sampled = false;
            _rate = null;
            _periodStart = _stopWatch.Elapsed;
        }

        private double ElapsedSeconds() => (_stopWatch.Elapsed - _periodStart).TotalSeconds;

        private void UpdateCount()
        {
            double priorCount = Count;
            Count = _currentCount;

            if (Count.IsNotEqualTo(priorCount))
                _rate = null;
        }

        private void Sample(double scale, bool force = false)
        {
            _currentCount = _currentItemCount * scale;

            if (Sampled) return;
            if (!force) return;

            UpdateCount();
        }

        private bool UpdateCore(int count)
        {
            _currentElapsedSeconds = ElapsedSeconds();
            _currentItemCount += count;

            if (_currentElapsedSeconds < _refreshSeconds) return false;

            Sample(_sampleSeconds / _currentElapsedSeconds);
            UpdateCount();
            //Console.WriteLine($"***** updated to {Count:F0} based on currentElapsedSeconds {_currentElapsedSeconds} and {_currentItemCount} - {Scheduler.Now.TimeOfDay}");
            _currentItemCount = 0;
            Sampled = true;
            _periodStart = _stopWatch.Elapsed;
            return true;
        }
    }
}
