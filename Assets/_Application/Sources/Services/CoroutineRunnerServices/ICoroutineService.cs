using System;
using System.Collections;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public interface ICoroutineService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
        Coroutine RunWithDelay(float delay, Action action);
        Coroutine RunEachFrame(Action action, bool andNow = false);
        Coroutine RunEachFixedUpdate(Action action);
        Coroutine RunEachSeconds(float period, Action action, bool andNow = false);
        Coroutine RunNextFixedUpdate(Action action);
        Coroutine RunWithFrameDelay(int frames, Action action);
        Coroutine RunNextFrame(Action action);
        Coroutine RunWhen(Func<bool> shouldRun, Action action);
        Coroutine IncreaseNormalValue(float seconds, Action<float> action);
        Coroutine ChangeValue(float valueFrom, float valueTo, float seconds, Action<float> action);
    }
}