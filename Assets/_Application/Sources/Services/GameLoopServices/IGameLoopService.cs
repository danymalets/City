using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Utils.Di;

namespace Sources.Services.GameLoopServices
{
    public interface IGameLoopService : IService
    {
        UniTaskVoid RunEachFrame(Action action, bool shouldRunNow = true, CancellationToken cancellationToken = default);
        UniTaskVoid RunEachSeconds(float period, Action action, bool shouldRunNow = true, CancellationToken cancellationToken = default);
        UniTaskVoid RunEachFixedUpdate(Action action, CancellationToken cancellationToken = default);
        UniTask ChangeValue(float sourceValue, float targetValue, float time, Action<float> onValueChanged, CancellationToken cancellationToken = default);
        UniTask IncreaseNormalValue(float seconds, Action<float> action, CancellationToken cancellationToken = default);
        CancellationToken CombineWithApplicationQuit(CancellationToken cancellationToken);
        CancellationToken GetApplicationQuitCancellationToken();
    }
}