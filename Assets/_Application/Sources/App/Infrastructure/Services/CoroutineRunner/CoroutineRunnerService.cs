using System;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.CoroutineRunner
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
    }
}