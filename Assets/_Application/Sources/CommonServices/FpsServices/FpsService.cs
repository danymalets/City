using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Application.Sources.CommonServices.CoroutineRunnerServices;
using _Application.Sources.CommonServices.TimeServices;
using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.CommonServices.FpsServices
{
    public class FpsService : IFpsService, IInitializable
    {
        public int FpsLastSecond { get; private set; }
        
        private ITimeService _timeService;

        private readonly Queue<float> _deltaTimes = new(150);

        private float _sumDeltaTimes = 0;
        private ICoroutineRunnerService _coroutineRunner;
        
        public void Initialize()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _coroutineRunner = DiContainer.Resolve<ICoroutineRunnerService>();
            _coroutineRunner.RunEachFrame(OnUpdate);
        }

        private void OnUpdate()
        {
            _sumDeltaTimes += _timeService.DeltaTime;
            _deltaTimes.Enqueue(_timeService.DeltaTime);

            while (_sumDeltaTimes > 1f && _deltaTimes.Any())
            {
                _sumDeltaTimes -= _deltaTimes.Dequeue();
            }

            FpsLastSecond = Mathf.RoundToInt(_deltaTimes.Count + 1);
        }

        public void RunWhenFpsStabilizes(Action action) =>
            _coroutineRunner.StartCoroutine(RunWhenFpsStabilizesCoroutine(action));

        private IEnumerator RunWhenFpsStabilizesCoroutine(Action action)
        {
            yield return new WaitForSeconds(0.5f);

            int fps;
            do
            {
                fps = FpsLastSecond;
                Debug.Log($"fps: {fps}");
                yield return new WaitForSeconds(0.5f);
            } 
            while (FpsLastSecond > fps);
            
            Debug.Log($"fps: {FpsLastSecond} - stable");

            action();
        }
    }
}