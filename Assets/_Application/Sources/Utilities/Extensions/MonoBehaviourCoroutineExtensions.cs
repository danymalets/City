using System;
using System.Collections;
using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class MonoBehaviourCoroutineExtensions
    {
        public static Coroutine RunWithDelay(this MonoBehaviour behaviour, float delay, Action action) => 
            behaviour.StartCoroutine(RunWithDelay(delay, action));
        
        public static Coroutine DoEachFrame(this MonoBehaviour behaviour, float duration, Action<float> action) => 
            behaviour.StartCoroutine(DoEachFrameCoroutine(duration, action));

        public static Coroutine ChangeEachFrame(this MonoBehaviour behaviour,
            float duration, float sourceValue, float targetValue, Action<float> valueChanged) => 
            behaviour.StartCoroutine(ChangeEachFrameCoroutine(duration, sourceValue, targetValue, valueChanged));
        
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
        
        public static Coroutine RunEachFrame(this MonoBehaviour behaviour, Action action, bool andNow = false) => 
            behaviour.StartCoroutine(RunEachFrame(action, andNow));

        private static IEnumerator RunEachFrame(Action action, bool andNow)
        {
            if (andNow)
                action?.Invoke();

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

        public static Coroutine RunEachSeconds(this MonoBehaviour behaviour, float period, Action action, bool andNow) =>
            behaviour.StartCoroutine(RunEachSeconds(period, action, andNow));

        private static IEnumerator RunEachSeconds(float period, Action action, bool andNow)
        {
            if (andNow)
                action?.Invoke();

            while (true)
            {
                yield return new WaitForSeconds(period);
                action?.Invoke();
            }
        }
        
        public static IEnumerator DoEachFrameCoroutine(float duration, Action<float> elapsedTimeChanged)
        {
            for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
            {
                elapsedTimeChanged(elapsedTime);
                yield return null;
            }
            elapsedTimeChanged(duration);
        }
        
        public static IEnumerator ChangeEachFrameCoroutine(float duration,
            float sourceValue,
            float targetValue, 
            Action<float> valueChanged)
        {
            yield return DoEachFrameCoroutine(duration, elapsedTime =>
            {
                float progress = elapsedTime / duration;
                valueChanged(Mathf.Lerp(sourceValue, targetValue, progress));
            });
        }
    }
}