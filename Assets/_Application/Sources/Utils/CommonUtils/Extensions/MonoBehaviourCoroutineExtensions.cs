using System;
using System.Collections;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class MonoBehaviourCoroutineExtensions
    {
        public static Coroutine RunWhen(this MonoBehaviour behaviour, Func<bool> canRun, Action action) => 
            behaviour.StartCoroutine(RunWhen(canRun, action));

        private static IEnumerator RunWhen(Func<bool> canRun, Action action)
        {
            yield return new WaitUntil(canRun);
            action?.Invoke();
        }
    }
}