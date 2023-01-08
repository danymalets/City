using System;
using UnityEngine;

namespace Sources.Utilities
{
    public static class DTimeExecution
    {
        public static void Execute(Action action)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            action();
            watch.Stop();
            long ticks = watch.ElapsedTicks;

            Debug.Log($"Time execution in ticks: {ticks}");
        }
    }
}