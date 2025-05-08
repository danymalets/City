using System;
using System.Diagnostics;

namespace Sources.Utils.CommonUtils.Utils
{
    public static class PerformanceUtils
    {
        public static void Execute(Action action, Action<long> onExecuted) => 
            onExecuted?.Invoke(Execute(action));

        public static long Execute(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action?.Invoke();
            watch.Stop();
            long ticks = watch.ElapsedTicks;
            return ticks;
        }
    }
}