using System;
using System.Collections;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public partial class CoroutineService
    {
        public Coroutine RunWithFrameDelay(int frames, Action action) => 
            StartCoroutine(RunWithFrameDelayCoroutine(frames, action));

        public Coroutine RunNextFrame(Action action) =>
            RunWithFrameDelay(1, action);

        private IEnumerator RunWithFrameDelayCoroutine(int frames, Action action)
        {
            for (int i = 0; i < frames; i++)
                yield return null;
            
            action?.Invoke();
        }
    }
}