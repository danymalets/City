using System;
using System.Collections;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService 
    {
        public Coroutine ChangeValue(float valueFrom, float valueTo, float seconds, Action<float> action, Action onCompleted = null) =>
            StartCoroutine(IncreaseNormalValueCoroutine(seconds, normalValue => 
                action?.Invoke(Mathf.Lerp(valueFrom, valueTo, normalValue)), onCompleted));
        
        public Coroutine IncreaseNormalValue(float seconds, Action<float> action, Action onCompleted) =>
            StartCoroutine(IncreaseNormalValueCoroutine(seconds, action, onCompleted));

        private IEnumerator IncreaseNormalValueCoroutine(float seconds, Action<float> action, Action onCompleted = null)
        {
            for (float elapsedTime = 0; elapsedTime < seconds; elapsedTime += Time.deltaTime)
            {
                action(elapsedTime / seconds);
                yield return null;
            }
            action?.Invoke(1);
            onCompleted?.Invoke();
        }
    }
}