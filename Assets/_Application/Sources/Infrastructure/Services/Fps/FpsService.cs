using System.Collections.Generic;
using System.Linq;
using Sources.Data.Live;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Times;
using UnityEngine;

namespace Sources.Infrastructure.Services.Fps
{
    public class FpsService : IFpsService, IInitializable
    {
        public LiveInt FpsLastSecond { get; } = new(0);
        
        private CoroutineContext _coroutineContext;
        private ITimeService _timeService;
        
        private readonly Queue<float> _deltaTimes = new(150);
        private float _sumDeltaTimes = 0;

        public void Initialize()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _coroutineContext = new CoroutineContext();
            _coroutineContext.RunEachFrame(OnUpdate);
        }

        private void OnUpdate()
        {
            _sumDeltaTimes += _timeService.DeltaTime;
            _deltaTimes.Enqueue(_timeService.DeltaTime);

            while (_sumDeltaTimes > 1f && _deltaTimes.Any())
            {
                _sumDeltaTimes -= _deltaTimes.Dequeue();
            }

            FpsLastSecond.Value = Mathf.RoundToInt((_deltaTimes.Count + 0.5f) / _sumDeltaTimes);
        }
    }
}