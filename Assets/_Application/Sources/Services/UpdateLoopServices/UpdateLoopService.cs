using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Services.ApplicationServices;
using Sources.Services.TimeServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.UpdateLoopServices
{
    public class UpdateLoopService : IUpdateLoopService, IInitializable
    {
        private readonly ITimeService _timeService;
        private readonly IApplicationService _applicationService;
        private readonly CancellationTokenSource _applicationCancellationTokenSource;

        public UpdateLoopService()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _applicationService = DiContainer.Resolve<IApplicationService>();
            _applicationCancellationTokenSource = new CancellationTokenSource();
        }

        public void Initialize()
        {
            _applicationService.ApplicationQuit += ApplicationService_OnApplicationQuit;
        }

        private void ApplicationService_OnApplicationQuit()
        {
            _applicationCancellationTokenSource.Cancel();
        }

        public async UniTaskVoid RunEachSeconds(float period, Action action, bool shouldRunNow, CancellationToken cancellationToken = default)
        {
            AssertUtils.IsTrue(period > 0);

            var timer = shouldRunNow ? 0 : period;

            while (true)
            {
                while (timer <= 0)
                {
                    timer += period;
                    action?.Invoke();
                }

                timer -= _timeService.DeltaTime;
                
                await UniTask.NextFrame(cancellationToken);
            }
        }

        public async UniTaskVoid RunEachFrame(Action action, bool shouldRunNow, CancellationToken cancellationToken = default)
        {
            if (!shouldRunNow)
            {
                await UniTask.NextFrame(cancellationToken);
            }

            while (true)
            {                
                action?.Invoke();
                await UniTask.NextFrame(cancellationToken);
            }
        }

        public async UniTaskVoid RunEachFixedUpdate(Action action, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                await UniTask.WaitForFixedUpdate(cancellationToken);
                action?.Invoke();
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
                await UniTask.NextFrame(cancellationToken);
            }
            action?.Invoke(1);
        }

        public CancellationTokenSource CreateCancellationTokenSource() =>
            CancellationTokenSource.CreateLinkedTokenSource(GetApplicationQuitCancellationToken());

        private CancellationToken GetApplicationQuitCancellationToken() => _applicationCancellationTokenSource.Token;
    }
}