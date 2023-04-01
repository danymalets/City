using System;
using System.Collections;
using UnityEngine;

namespace Sources.Utils.Libs
{
    public static class CoroutineUtility
    {
        public static IEnumerator DoEachFrame(float duration, Action<float> elapsedTimeChanged)
        {
            for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
            {
                elapsedTimeChanged(elapsedTime);
                yield return null;
            }
            elapsedTimeChanged(duration);
        }
        
        public static IEnumerator ChangeEachFrame(float duration,
            float sourceValue,
            float targetValue, 
            Action<float> valueChanged)
        {
            yield return DoEachFrame(duration, elapsedTime =>
            {
                float progress = elapsedTime / duration;
                valueChanged(Mathf.Lerp(sourceValue, targetValue, progress));
            });
        }
    }
}