using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.TimeServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.FpsServices
{
    public class FpsService : IFpsService, IInitializable
    {
        public float FpsLastSecond { get; private set; }

        private ITimeService _timeService;

        private readonly Queue<float> _deltaTimes = new(150);

        private float _sumDeltaTimes = 0;
        private ICoroutineService _coroutine;

        public void Initialize()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _coroutine = DiContainer.Resolve<ICoroutineService>();
            _coroutine.RunEachFrame(OnUpdate);
        }

        private void OnUpdate()
        {
            _sumDeltaTimes += _timeService.DeltaTime;
            _deltaTimes.Enqueue(_timeService.DeltaTime);

            while (_sumDeltaTimes > 1f && _deltaTimes.Any())
            {
                _sumDeltaTimes -= _deltaTimes.Dequeue();
            }

            FpsLastSecond = _deltaTimes.Count / _sumDeltaTimes;
        }

        public void RunWhenFpsStabilizes(Action action) =>
            _coroutine.StartCoroutine(RunWhenFpsStabilizesCoroutine(action));

        private IEnumerator RunWhenFpsStabilizesCoroutine(Action action)
        {
            yield return new WaitForSeconds(2f);

            float fps;
            do
            {
                fps = FpsLastSecond;
                Debug.Log($"fps: {fps:F1}");
                yield return new WaitForSeconds(0.5f);
            } while (FpsLastSecond > fps);

            Debug.Log($"fps: {FpsLastSecond:F1} - stable");

            action();
        }
    }
}