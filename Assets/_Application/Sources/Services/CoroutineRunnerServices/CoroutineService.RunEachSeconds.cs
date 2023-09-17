using System;
using System.Collections;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunEachSeconds(float period, Action action, bool andNow = false) =>
            StartCoroutine(RunEachSecondsCoroutine(period, action, andNow));
        
        private static IEnumerator RunEachSecondsCoroutine(float period, Action action, bool andNow)
        {
            if (andNow)
                action?.Invoke();

            while (true)
            {
                yield return new WaitForSeconds(period);
                action?.Invoke();
            }
        }
    }
}