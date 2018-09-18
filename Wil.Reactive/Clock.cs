using System;
using System.Reactive.Concurrency;
using Wil.Core.Interfaces;

namespace Wil.Reactive
{
    public class Clock : IClock
    {
        public Clock(IScheduler scheduler = null)
        {
            _scheduler = scheduler ?? Scheduler.Default;

            _startTime = NowOffset;
        }

        public TimeSpan Elapsed => CalculateElapsed(Ticks);
        public long Ticks => NowOffset.Ticks - _startTime.Ticks;
        public long DateTimeTicks => Ticks;

        public DateTimeOffset NowOffset => _scheduler.Now;
        public DateTime UtcNow => _scheduler.Now.UtcDateTime;
        public DateTime Now => _scheduler.Now.LocalDateTime;

        public DateTimeOffset ToDateTimeOffset(long elapsedTicks)
            => new DateTimeOffset(new DateTime(_startTime.Ticks + elapsedTicks, DateTimeKind.Utc));

        public DateTime ToDateTime(long elapsedTicks) => ToDateTimeOffset(elapsedTicks).LocalDateTime;
        public TimeSpan CalculateElapsed(long elapsedTicks) => TimeSpan.FromTicks(elapsedTicks);

        private readonly IScheduler _scheduler;
        private readonly DateTimeOffset _startTime;
    }
}
