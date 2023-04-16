using System;
using System.Diagnostics;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DPerformance
    {
        public static void Execute(Action action, Action<long> onExecuted)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            long ticks = watch.ElapsedTicks;
            onExecuted?.Invoke(ticks);
        }
    }
}