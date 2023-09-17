using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public class CoroutineContext
    {
        private readonly ICoroutineService _coroutine;
        private readonly List<Coroutine> _runningCoroutines = new List<Coroutine>();

        public CoroutineContext()
        {
            _coroutine = DiContainer.Resolve<ICoroutineService>();
        }

        public Coroutine StartCoroutine(IEnumerator coroutineMethod)
        {
            Coroutine coroutine = _coroutine.StartCoroutine(coroutineMethod);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWithDelay(float delay, Action action)
        {
            Coroutine coroutine = _coroutine.RunWithDelay(delay, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunEachFrame(Action action, bool andNow = false)
        {
            Coroutine coroutine = _coroutine.RunEachFrame(action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunEachFixedUpdate(Action action)
        {
            Coroutine coroutine = _coroutine.RunEachFixedUpdate(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public void StopAllCoroutines()
        {
            foreach (Coroutine coroutine in _runningCoroutines)
                _coroutine.StopCoroutine(coroutine);
        }

        public Coroutine RunEachSeconds(float period, Action action, bool andNow = false)
        {
            Coroutine coroutine = _coroutine.RunEachSeconds(period, action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunNextFixedUpdate(Action action)
        {
            Coroutine coroutine = _coroutine.RunNextFixedUpdate(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWithFrameDelay(int frames, Action action)
        {
            Coroutine coroutine = _coroutine.RunWithFrameDelay(frames, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunNextFrame(Action action)
        {
            Coroutine coroutine = _coroutine.RunNextFrame(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine IncreaseNormalValue(float seconds, Action<float> action)
        {
            Coroutine coroutine = _coroutine.IncreaseNormalValue(seconds, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine ChangeValue(float valueFrom, float valueTo, float seconds, Action<float> action)
        {
            Coroutine coroutine = _coroutine.ChangeValue(valueFrom, valueTo, seconds, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
    }
}