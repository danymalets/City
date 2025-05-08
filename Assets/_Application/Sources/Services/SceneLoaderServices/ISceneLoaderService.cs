using System;
using Cysharp.Threading.Tasks;
using Sources.Utils.Di;
using UnityEngine.SceneManagement;

namespace Sources.Services.SceneLoaderServices
{
    public interface ISceneLoaderService : IService
    {
        UniTask LoadEmptyScene();
        UniTask<T> LoadScene<T>(string scene, LoadSceneMode loadSceneMode = LoadSceneMode.Single) where T : ISceneContext;
        UniTask LoadScene(string scene, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
        UniTask UnloadScene(string scene);
    }
}