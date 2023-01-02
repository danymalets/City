using System;
using Sources.Infrastructure.Bootstrap;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene<T>(Scene scene, Action<T> onComplete = null) where T : SceneContext;
        void LoadScene<T>(Scene scene, Action<float> onProgressChanged, Action<T> onComplete) where T : SceneContext;
    }
}