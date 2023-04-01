using System;
using System.Collections;
using Sources.App.Infrastructure.Bootstrap;
using Sources.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Sources.Services.SceneLoader
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private readonly CoroutineContext _coroutineContext;

        public SceneLoaderService()
        {
            _coroutineContext = new CoroutineContext();
        }

        public void LoadScene<T>(string scene, Action<T> onComplete = null)
            where T : SceneContext =>
            LoadScene(scene, null, onComplete);

        public void LoadScene<T>(string scene, Action<float> onProgressChanged, Action<T> onComplete) 
            where T : SceneContext => 
            _coroutineContext.StartCoroutine(LoadSceneCoroutine(scene, onProgressChanged, onComplete));

        private IEnumerator LoadSceneCoroutine<T>(
            string scene, 
            Action<float> onProgressChanged, 
            Action<T> onComplete) where T : SceneContext
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
            
            while (!operation.isDone)
            {
                onProgressChanged?.Invoke(operation.progress);
                yield return null;
            }

            yield return null;

            T sceneContext = GameObject.FindObjectOfType<T>();
            
            onComplete?.Invoke(sceneContext);
        }
    }
}