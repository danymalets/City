using System;
using System.Collections;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunEachFrameWithTime(float duration, Action<float> action) => 
            StartCoroutine(RunEachFrameWithTimeCoroutine(duration, action));

        public Coroutine ChangeValueEachFrame(float duration, float sourceValue, float targetValue,
            Action<float> valueChanged) => 
            StartCoroutine(ChangeValueEachFrameCoroutine(duration, sourceValue, targetValue, valueChanged));

        private static IEnumerator RunEachFrameWithTimeCoroutine(float duration, Action<float> elapsedTimeChanged)
        {
            for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
            {
                elapsedTimeChanged(elapsedTime);
                yield return null;
            }
            elapsedTimeChanged(duration);
        }

        private static IEnumerator ChangeValueEachFrameCoroutine(float duration,
            float sourceValue,
            float targetValue, 
            Action<float> valueChanged)
        {
            yield return RunEachFrameWithTimeCoroutine(duration, elapsedTime =>
            {
                float progress = elapsedTime / duration;
                valueChanged(Mathf.Lerp(sourceValue, targetValue, progress));
            });
        }
    }
}