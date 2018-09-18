using System;

namespace Wil.Core.Interfaces
{
    public interface IClock
    {
        long Ticks { get; }
        long DateTimeTicks { get; }
        TimeSpan Elapsed { get; }
        DateTimeOffset NowOffset { get; }
        DateTime UtcNow { get; }
        DateTime Now { get; }

        DateTimeOffset ToDateTimeOffset(long elapsedTicks);
        DateTime ToDateTime(long elapsedTicks);
        TimeSpan CalculateElapsed(long elapsedTicks);
    }
}
