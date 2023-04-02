using System;
using System.Collections;
using Sources.Data;
using Sources.Monos;
using Sources.Services.CoroutineRunner;
using Sources.Utils.Libs;
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
            where T : ISceneContext =>
            LoadScene(scene, null, onComplete);

        public void LoadScene<T>(string scene, Action<float> onProgressChanged, Action<T> onComplete) 
            where T : ISceneContext => 
            _coroutineContext.StartCoroutine(LoadSceneCoroutine(scene, onProgressChanged, onComplete));

        private IEnumerator LoadSceneCoroutine<T>(
            string scene, 
            Action<float> onProgressChanged, 
            Action<T> onComplete) where T : ISceneContext
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
            
            while (!operation.isDone)
            {
                onProgressChanged?.Invoke(operation.progress);
                yield return null;
            }

            yield return null;

            T sceneContext = GameObject.FindObjectOfType<SceneContext>()
                .gameObject.GetComponent<T>();
            
            DAssert.IsTrue(sceneContext != null);
            
            onComplete?.Invoke(sceneContext);
        }
    }
}