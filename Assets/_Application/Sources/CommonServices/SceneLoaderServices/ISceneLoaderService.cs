using System;
using Sources.Utils.Di;

namespace Sources.CommonServices.SceneLoaderServices
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene<T>(string scene, Action<T> onComplete = null) where T : ISceneContext;
        void LoadScene<T>(string scene, Action<float> onProgressChanged, Action<T> onComplete) where T : ISceneContext;
    }
}