using System;
using System.Collections;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunNextFixedUpdate(Action action) =>
            RunNextFixedUpdateFramesDelay(1, action);

        private Coroutine RunNextFixedUpdateFramesDelay(int count, Action action) =>
            StartCoroutine(RunNextFixedUpdateCoroutine(count, action));

        private static IEnumerator RunNextFixedUpdateCoroutine(int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForFixedUpdate();
            }
            action?.Invoke();
        }
    }
}