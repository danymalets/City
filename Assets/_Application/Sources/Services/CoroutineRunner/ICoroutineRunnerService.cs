using System;
using System.Collections;
using Sources.Services.Di;
using UnityEngine;

namespace Sources.Services.CoroutineRunner
{
    public interface ICoroutineRunnerService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
        
        Coroutine RunWithDelay(float delay, Action action);
        
        Coroutine RunEachFrame(Action action, bool andNow = false);
        Coroutine RunEachFixedUpdate(Action action);
        Coroutine RunEachSeconds(float period, Action action, bool andNow = false);
    }
}