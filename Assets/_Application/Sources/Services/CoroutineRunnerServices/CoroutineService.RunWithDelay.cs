using System;
using System.Collections;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunWithDelay(float delay, Action action) => 
            StartCoroutine(RunWithDelayCoroutine(delay, action));
        
        private static IEnumerator RunWithDelayCoroutine(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
    }
}