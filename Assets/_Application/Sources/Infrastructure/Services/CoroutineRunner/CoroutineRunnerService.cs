using System;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Infrastructure.Services.CoroutineRunner
{
    public class CoroutineRunnerService : MonoBehaviour, ICoroutineRunnerService
    {
        public Coroutine RunWithDelay(float delay, Action action) => 
            MonoBehaviourExtensions.RunWithDelay(this, delay, action);

        public Coroutine RunEachFrame(Action action) =>
            MonoBehaviourExtensions.RunEachFrame(this, action);

        public Coroutine RunEachPhysicalUpdate(Action action) =>
            MonoBehaviourExtensions.RunEachFixedUpdate(this, action);

        public Coroutine RunEachSeconds(float period, Action action) =>
            MonoBehaviourExtensions.RunEachSeconds(this, period, action);
    }
}