using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public class CoroutineContext
    {
        private readonly ICoroutineRunnerService _coroutineRunner;
        private readonly List<Coroutine> _runningCoroutines = new List<Coroutine>();

        internal CoroutineContext()
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

        public void StopAllCoroutines()
        {
            foreach (Coroutine coroutine in _runningCoroutines)
                _coroutineRunner.StopCoroutine(coroutine);
        }

        public Coroutine RunEachSeconds(float period, Action action, bool andNow = false)
        {
            Coroutine coroutine = _coroutineRunner.RunEachSeconds(period, action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunNextFixedUpdate(Action action)
        {
            Coroutine coroutine = _coroutineRunner.RunNextFixedUpdate(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWithFrameDelay(int frames, Action action)
        {
            Coroutine coroutine = _coroutineRunner.RunWithFrameDelay(frames, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunNextFrame(Action action)
        {
            Coroutine coroutine = _coroutineRunner.RunNextFrame(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine IncreaseNormalValue(float seconds, Action<float> action)
        {
            Coroutine coroutine = _coroutineRunner.IncreaseNormalValue(seconds, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine ChangeValue(float valueFrom, float valueTo, float seconds, Action<float> action)
        {
            Coroutine coroutine = _coroutineRunner.ChangeValue(valueFrom, valueTo, seconds, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
    }
}