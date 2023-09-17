using System;
using System.Collections;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunEachFixedUpdate(Action action) =>
            StartCoroutine(RunEachFixedUpdateCoroutine(action));
        
        private static IEnumerator RunEachFixedUpdateCoroutine(Action action)
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();
                action?.Invoke();
            }
        }
    }
}