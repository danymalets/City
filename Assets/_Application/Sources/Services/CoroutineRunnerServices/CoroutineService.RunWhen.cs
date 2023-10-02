using System;
using System.Collections;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunWhen(Func<bool> shouldRun, Action action) => 
            StartCoroutine(RunNextFrameCoroutine(shouldRun, action));

        private IEnumerator RunNextFrameCoroutine(Func<bool> shouldRun, Action action)
        {
            yield return new WaitUntil(shouldRun);
            action?.Invoke();
        }
    }
}