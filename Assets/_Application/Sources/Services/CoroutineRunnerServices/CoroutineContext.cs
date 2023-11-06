using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.CoroutineRunnerServices
{
    public class CoroutineContext
    {
        private readonly ICoroutineService _coroutineService;
        private readonly List<Coroutine> _runningCoroutines = new List<Coroutine>();

        public CoroutineContext()
        {
            _coroutineService = DiContainer.Resolve<ICoroutineService>();
        }

        public Coroutine StartCoroutine(IEnumerator coroutineMethod)
        {
            Coroutine coroutine = _coroutineService.StartCoroutine(coroutineMethod);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWithDelay(float delay, Action action)
        {
            Coroutine coroutine = _coroutineService.RunWithDelay(delay, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunEachFrame(Action action, bool andNow)
        {
            Coroutine coroutine = _coroutineService.RunEachFrame(action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunEachFixedUpdate(Action action)
        {
            Coroutine coroutine = _coroutineService.RunEachFixedUpdate(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public void StopAllCoroutines()
        {
            foreach (Coroutine coroutine in _runningCoroutines)
                _coroutineService.StopCoroutine(coroutine);
        }

        public Coroutine RunEachSeconds(float period, Action action, bool andNow = false)
        {
            Coroutine coroutine = _coroutineService.RunEachSeconds(period, action, andNow);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunNextFixedUpdate(Action action)
        {
            Coroutine coroutine = _coroutineService.RunNextFixedUpdate(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWithFrameDelay(int frames, Action action)
        {
            Coroutine coroutine = _coroutineService.RunWithFrameDelay(frames, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine RunNextFrame(Action action)
        {
            Coroutine coroutine = _coroutineService.RunNextFrame(action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine IncreaseNormalValue(float seconds, Action<float> action)
        {
            Coroutine coroutine = _coroutineService.IncreaseNormalValue(seconds, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
        
        public Coroutine ChangeValue(float valueFrom, float valueTo, float seconds, Action<float> action)
        {
            Coroutine coroutine = _coroutineService.ChangeValue(valueFrom, valueTo, seconds, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }

        public Coroutine RunWhen(Func<bool> shouldRun, Action action)
        {
            Coroutine coroutine = _coroutineService.RunWhen(shouldRun, action);
            _runningCoroutines.Add(coroutine);
            return coroutine;
        }
    }
}