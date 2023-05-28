using System;
using Sources.Utils.Di;

namespace Sources.Services.SceneLoaderServices
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene<T>(string scene, Action<T> onComplete = null) where T : ISceneContext;
        void LoadScene(string scene, Action onComplete = null);
    }
}