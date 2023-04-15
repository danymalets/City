using System;
using System.Collections;
using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.CommonServices.CoroutineRunnerServices
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