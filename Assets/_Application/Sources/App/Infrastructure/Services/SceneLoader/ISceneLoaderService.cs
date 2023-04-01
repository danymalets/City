using System;
using Sources.App.Infrastructure.Bootstrap;

namespace Sources.App.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene<T>(string scene, Action<T> onComplete = null) where T : SceneContext;
        void LoadScene<T>(string scene, Action<float> onProgressChanged, Action<T> onComplete) where T : SceneContext;
    }
}