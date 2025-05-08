using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Services.SceneLoaderServices
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private const string EmptySceneName = "Empty";

        public SceneLoaderService()
        {
            
        }

        public UniTask LoadEmptyScene() => 
            LoadScene(EmptySceneName);

        public async UniTask<T> LoadScene<T>(string scene, 
            LoadSceneMode loadSceneMode = LoadSceneMode.Single) where T : ISceneContext
        {
            await LoadScene(scene, loadSceneMode);
            
            return GameObject.FindObjectsOfType<SceneContext>()
                .Select(sc => sc.gameObject.GetComponent<T>())
                .First(sc => sc != null);
        }

        public async UniTask LoadScene(string scene, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(scene, loadSceneMode);
            await UniTask.NextFrame();
        }

        public async UniTask UnloadScene(string scene) 
        {
            await SceneManager.UnloadSceneAsync(scene);
        }
    }
}