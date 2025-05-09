using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Services.TimeServices;
using Sources.Utils.CommonUtils.EditorTools;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.GameLoopServices
{
    public class GameLoopService : IGameLoopService
    {
        private readonly ITimeService _timeService;

        public GameLoopService()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
        }
        
        public async UniTaskVoid RunEachSeconds(float period, Action action, bool shouldRunNow, CancellationToken cancellationToken = default)
        {
            AssertUtils.IsTrue(period > 0);
            float timer = shouldRunNow ? 0 : period;

            while (!cancellationToken.IsCancellationRequested)
            {
                while (timer <= 0)
                {
                    timer += period;
                    action?.Invoke();
                }

                timer -= _timeService.DeltaTime;
                
                await UniTask.NextFrame();
            }
        }

        public async UniTaskVoid RunEachFrame(Action action, bool shouldRunNow, CancellationToken cancellationToken = default)
        {
            if (!shouldRunNow)
            {
                await UniTask.NextFrame();
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                action?.Invoke();
                await UniTask.NextFrame();
            }
        }

        public async UniTaskVoid RunEachFixedUpdate(Action action, CancellationToken cancellationToken = default)
        {
            await UniTask.WaitForFixedUpdate();

            while (!cancellationToken.IsCancellationRequested)
            {
                action?.Invoke();
                await UniTask.WaitForFixedUpdate();
            }
        }

        public async UniTask ChangeValue(float sourceValue, float targetValue, float time, Action<float> onValueChanged,
            CancellationToken cancellationToken = default)
        {
            await IncreaseNormalValue(time, normalValue => onValueChanged?.Invoke(Mathf.Lerp(sourceValue, targetValue, normalValue)), cancellationToken);
        }

        public async UniTask IncreaseNormalValue(float seconds, Action<float> action, CancellationToken cancellationToken = default)
        {
            for (float elapsedTime = 0; elapsedTime < seconds && !cancellationToken.IsCancellationRequested; elapsedTime += Time.deltaTime)
            {
                action(elapsedTime / seconds);
                await UniTask.NextFrame();
            }
            action?.Invoke(1);
        }
    }
}