using System;
using System.Reactive.Concurrency;
using Wil.Core.Interfaces;

namespace Wil.Reactive.Interfaces
{
    public interface ISpeedometer
    {
        IScheduler Scheduler { get; }
        double Count { get; }
        Duration Period { get; }
        Rate Rate { get; }
        bool Sampled { get; }
        string PeriodString { get; set; }
        string CountFormatString { get; set; }
        string PeriodSeparator { get; set; }

        void Start();
        bool Update(int count = 1, bool force = false);
    }
}
