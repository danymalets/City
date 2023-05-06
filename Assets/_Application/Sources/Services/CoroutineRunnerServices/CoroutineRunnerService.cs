using System;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public class CoroutineRunnerService : MonoBehaviour, ICoroutineRunnerService
    {
        public Coroutine RunWithDelay(float delay, Action action) => 
            MonoBehaviourCoroutineExtensions.RunWithDelay(this, delay, action);

        public Coroutine RunEachFrame(Action action, bool andNow) =>
            MonoBehaviourCoroutineExtensions.RunEachFrame(this, action, andNow);

        public Coroutine RunEachFixedUpdate(Action action) =>
            MonoBehaviourCoroutineExtensions.RunEachFixedUpdate(this, action);

        public Coroutine RunEachSeconds(float period, Action action, bool andNow = false) =>
            MonoBehaviourCoroutineExtensions.RunEachSeconds(this, period, action, andNow);

        public Coroutine RunNextFixedUpdate(Action action) => 
            MonoBehaviourCoroutineExtensions.RunNextFixedUpdate(this, action);
    }
}