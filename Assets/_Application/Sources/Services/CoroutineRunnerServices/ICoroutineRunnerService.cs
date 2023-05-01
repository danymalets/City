using System;
using System.Collections;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
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