using System;
using System.Collections;
using UnityEngine;

namespace Sources.Infrastructure.Services.CoroutineRunner
{
    public interface ICoroutineRunnerService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
        
        Coroutine RunWithDelay(float delay, Action action);
        
        Coroutine RunEachFrame(Action action);
        Coroutine RunEachPhysicalUpdate(Action action);
        Coroutine RunEachSeconds(float period, Action action);
    }
}