using System;
using System.Diagnostics;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DPerformance
    {
        public static long Execute(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            long ticks = watch.ElapsedTicks;
            return ticks;
        }
    }
}