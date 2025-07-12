using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sources.Services.LogServices;
using Sources.Services.TimeServices;
using Sources.Services.UpdateLoopServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;
using ILogger = Sources.Services.LogServices.ILogger;

namespace Sources.Services.FpsServices
{
    public class FpsService : IFpsService, IInitializable
    {
        public float FpsLastSecond { get; private set; }

        private readonly ITimeService _timeService;
        private readonly Queue<float> _deltaTimes = new(150);
        private float _sumDeltaTimes = 0;
        private readonly IUpdateLoopService _updateLoopService;
        private readonly ILogger _logger;
        
        public FpsService()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _updateLoopService = DiContainer.Resolve<IUpdateLoopService>();
            _logger = DiContainer.Resolve<ILogService>().CreateLogger<FpsService>();
        }

        public void Initialize()
        {
            _updateLoopService.RunEachFrame(OnUpdate, false);
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
        }
    }
}