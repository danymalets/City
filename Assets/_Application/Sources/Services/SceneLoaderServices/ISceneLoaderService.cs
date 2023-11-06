using System;
using Sources.Utils.Di;
using UnityEngine.SceneManagement;

namespace Sources.Services.SceneLoaderServices
{
    public interface ISceneLoaderService : IService
    {
        void LoadEmptyScene(Action onComplete = null);
        void LoadScene<T>(string scene, Action<T> onComplete = null, 
            LoadSceneMode loadSceneMode = LoadSceneMode.Single) where T : ISceneContext;
        void LoadScene(string scene, Action onComplete = null,
            LoadSceneMode loadSceneMode = LoadSceneMode.Single);
        void UnloadScene(string scene, Action onCompleted = null);
    }
}