using System;
using System.Collections;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService 
    {
        public Coroutine ChangeValue(float valueFrom, float valueTo, float seconds, Action<float> action) =>
            StartCoroutine(IncreaseNormalValueCoroutine(seconds, normalValue => 
                action?.Invoke(Mathf.Lerp(valueFrom, valueTo, normalValue))));
        
        public Coroutine IncreaseNormalValue(float seconds, Action<float> action) =>
            StartCoroutine(IncreaseNormalValueCoroutine(seconds, action));

        private IEnumerator IncreaseNormalValueCoroutine(float seconds, Action<float> action)
        {
            for (float elapsedTime = 0; elapsedTime < seconds; elapsedTime += Time.deltaTime)
            {
                action(elapsedTime / seconds);
                yield return null;
            }
            action?.Invoke(1);
        }
    }
}