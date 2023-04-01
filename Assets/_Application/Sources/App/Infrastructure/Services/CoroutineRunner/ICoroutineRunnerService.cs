using System;
using System.Collections;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.CoroutineRunner
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