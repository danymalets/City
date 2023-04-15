using System;
using System.Collections;
using System.Collections.Generic;
using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.CommonServices.CoroutineRunnerServices
{
    public class CoroutineContext
    {
        private readonly ICoroutineRunnerService _coroutineRunner;
        private readonly List<Coroutine> _runningCoroutines = new List<Coroutine>();

        public CoroutineContext()
        {
            _coroutineRunner = DiContainer.Resolve<ICoroutineRunnerService>();
        }

        public Coroutine StartCoroutine(IEnumerator coroutineMethod)
        {
            Coroutine coroutine = _coroutineRunner.StartCoroutine(coroutineMethod);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWithDelay(float delay, Action action)
        {
            Coroutine coroutine = _coroutineRunner.RunWithDelay(delay, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunEachFrame(Action action, bool andNow = false)
        {
            Coroutine coroutine = _coroutineRunner.RunEachFrame(action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunEachFixedUpdate(Action action)
        {
            Coroutine coroutine = _coroutineRunner.RunEachFixedUpdate(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public void StopCoroutine(Coroutine coroutine) =>
            _coroutineRunner.StopCoroutine(coroutine);

        public void StopAllCoroutines()
        {
            foreach (Coroutine coroutine in _runningCoroutines)
                StopCoroutine(coroutine);
        }

        public Coroutine RunEachSeconds(float period, Action action, bool andNow = false)
        {
            Coroutine coroutine = _coroutineRunner.RunEachSeconds(period, action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
    }
}