using System;
using Cysharp.Threading.Tasks;
using Sources.Utils.Di;

namespace Sources.Services.FpsServices
{
    public interface IFpsService : IService
    {
        float FpsLastSecond { get; }
        UniTask WaitForStableFps();
    }
}