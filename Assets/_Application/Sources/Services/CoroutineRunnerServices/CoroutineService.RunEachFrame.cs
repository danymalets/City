using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunEachFrame(Action action, bool andNow) =>
            StartCoroutine(RunEachFrameCoroutine(action, andNow));

        private static IEnumerator RunEachFrameCoroutine(Action action, bool andNow)
        {
            if (andNow)
                action?.Invoke();

            while (true)
            {
                yield return null;
                action?.Invoke();
            }
        }
    }
}