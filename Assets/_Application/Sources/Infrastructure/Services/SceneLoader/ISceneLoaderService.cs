using System;
using Sources.Infrastructure.Bootstrap;

namespace Sources.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene<T>(string scene, Action<T> onComplete = null) where T : SceneContext;
        void LoadScene<T>(string scene, Action<float> onProgressChanged, Action<T> onComplete) where T : SceneContext;
    }
}