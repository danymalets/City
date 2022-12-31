using System;

namespace Sources.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService : IService
    {
        void LoadSceneInOneFrame(string sceneName, Action onComplete = null);
        void LoadScene(string sceneName, Action onComplete = null);
        void LoadScene(string sceneName, Action<float> onProgressChanged, Action onComplete);
    }
}