using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sources.Services.CoroutineRunner;
using Sources.Services.Di;
using Sources.Services.Times;
using UnityEngine;

namespace Sources.Services.Fps
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