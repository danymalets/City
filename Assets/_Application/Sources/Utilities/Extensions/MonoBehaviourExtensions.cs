using System;
using System.Collections;
using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static Coroutine RunWithDelay(this MonoBehaviour behaviour, float delay, Action action) => 
            behaviour.StartCoroutine(RunWithDelay(delay, action));

        private static IEnumerator RunWithDelay(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }

        public static void TryStopCoroutine(this MonoBehaviour behaviour, Coroutine coroutine)
        {
            if (coroutine != null)
                behaviour.StopCoroutine(coroutine);
        }
        
        public static Coroutine RunWhen(this MonoBehaviour behaviour, Func<bool> canRun, Action action) => 
            behaviour.StartCoroutine(RunWhen(canRun, action));
        
        private static IEnumerator RunWhen(Func<bool> canRun, Action action)
        {
            yield return new WaitUntil(canRun);
            action?.Invoke();
        }
        
        public static Coroutine RunEachFrame(this MonoBehaviour behaviour, Action action) => 
            behaviour.StartCoroutine(RunEachFrame(action));

        private static IEnumerator RunEachFrame(Action action)
        {
            while (true)
            {
                yield return null;
                action?.Invoke();
            }
        }

        public static Coroutine RunEachFixedUpdate(this MonoBehaviour behaviour, Action action) =>
            behaviour.StartCoroutine(RunEachFixedUpdate(action));

        private static IEnumerator RunEachFixedUpdate(Action action)
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();
                action?.Invoke();
            }
        }

        public static Coroutine RunEachSeconds(this MonoBehaviour behaviour, float period, Action action) =>
            behaviour.StartCoroutine(RunEachSeconds(period, action));

        private static IEnumerator RunEachSeconds(float period, Action action)
        {
            while (true)
            {
                yield return new WaitForSeconds(period);
                action?.Invoke();
            }
        }
    }
}