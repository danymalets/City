using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sources.Services.TimeServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.FpsServices
{
    public class FpsService : IFpsService, IInitializable
    {
        public float FpsLastSecond { get; private set; }

        private readonly ITimeService _timeService;

        private readonly Queue<float> _deltaTimes = new(150);

        private float _sumDeltaTimes = 0;

        public FpsService()
        {            
            _timeService = DiContainer.Resolve<ITimeService>();
        }

        public void Initialize()
        {
            UniTasksUtils.RunEachUpdate(OnUpdate);
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

        public async UniTask WaitForStableFps()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2f));

            float fps;
            do
            {
                fps = FpsLastSecond;
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            } while (FpsLastSecond > fps);

            Debug.Log($"[FpsService] Fps: {FpsLastSecond:F1} - stable");
        }
    }
}