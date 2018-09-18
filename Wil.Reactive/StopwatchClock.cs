/*
using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using Wil.Core.Interfaces;

namespace Wil.Reactive
{
    // DO NOT USE
    // Need to figure out why the time drifts significantly when Thread.Sleep is used.
    public class StopwatchClock : IClock
    {
        public StopwatchClock(IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;

            _watch = scheduler.StartStopwatch();

            bool calibrated = false;
            DateTime now = scheduler.Now.LocalDateTime;
            DateTime clockNow = Now;

            double diff = now.TimeOfDay.TotalMilliseconds - clockNow.TimeOfDay.TotalMilliseconds;
            _ticksDiff = TimeSpan.FromMilliseconds(diff).Ticks + now.Ticks - now.TimeOfDay.Ticks;
            long best = _ticksDiff;
            double bestDiff = diff;
            double precision = 0.1;

            for (int i = 0; i < 1000; i++)
            {
                int successCount = 0;

                for (int j = 0; j < 5; j++)
                {
                    now = scheduler.Now.LocalDateTime;
                    clockNow = Now;

                    diff = now.TimeOfDay.TotalMilliseconds - clockNow.TimeOfDay.TotalMilliseconds;

                    if (Math.Abs(diff) < Math.Abs(bestDiff))
                    {
                        bestDiff = diff;
                        best = _ticksDiff;
                    }

                    if (Math.Abs(diff) > precision) break;

                    successCount++;
                }

                calibrated = successCount >= 5;

                if (calibrated) break;

                _ticksDiff = TimeSpan.FromMilliseconds(diff).Ticks + now.Ticks - now.TimeOfDay.Ticks;
            }

            if (!calibrated)
                _ticksDiff = best;
        }

        public TimeSpan Elapsed => _watch.Elapsed;
        public long Ticks => _watch.Elapsed.Ticks;
        public long DateTimeTicks => ToDateTimeTicks(Ticks);
        public DateTimeOffset UtcNowOffset => throw new NotImplementedException(); // TODO: Implement after drift corrected.
        public DateTimeOffset NowOffset => throw new NotImplementedException(); // TODO: Implement after drift corrected.
        public DateTime UtcNow => throw new NotImplementedException(); // TODO: Implement after drift corrected.
        public DateTime Now => ToDateTime(Ticks);

        public DateTimeOffset ToDateTimeOffset(long elapsedTicks) => throw new NotImplementedException(); // TODO: Implement after drift corrected.
        public DateTime ToDateTime(long elapsedTicks) => new DateTime(ToDateTimeTicks(elapsedTicks));
        public TimeSpan CalculateElapsed(long elapsedTicks) => new TimeSpan(DateTimeTicks - ToDateTimeTicks(elapsedTicks));

        private static readonly double Multiplier = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;

        private readonly IStopwatch _watch;
        private readonly long _ticksDiff;

        private long ToDateTimeTicks(long ticks) => (long)(ticks * Multiplier) + _ticksDiff;
    }
}
//*/
