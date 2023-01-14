using System;
using UnityEngine;

namespace Sources.Utilities
{
    public static class DPerformance
    {
        public static long Execute(Action action)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            action();
            watch.Stop();
            long ticks = watch.ElapsedTicks;
            return ticks;
        }
    }
}