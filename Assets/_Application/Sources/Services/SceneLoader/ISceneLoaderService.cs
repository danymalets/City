using System;
using Sources.Monos;
using Sources.Services.Di;

namespace Sources.Services.SceneLoader
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene<T>(string scene, Action<T> onComplete = null) where T : SceneContext;
        void LoadScene<T>(string scene, Action<float> onProgressChanged, Action<T> onComplete) where T : SceneContext;
    }
}