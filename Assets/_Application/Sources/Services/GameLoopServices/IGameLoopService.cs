using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Utils.Di;

namespace Sources.Services.GameLoopServices
{
    public interface IGameLoopService : IService
    {
        void RunEachFrame(Action action, bool shouldRunNow = true, CancellationToken cancellationToken = default);
        void RunEachSeconds(float period, Action action, bool shouldRunNow = true, CancellationToken cancellationToken = default);
        void RunEachFixedUpdate(Action action, CancellationToken cancellationToken = default);
        UniTask ChangeValue(float sourceValue, float targetValue, float time, Action<float> onValueChanged, CancellationToken cancellationToken = default);
        UniTask IncreaseNormalValue(float seconds, Action<float> action, CancellationToken cancellationToken = default);
    }
}