using System;
using System.Collections;
using System.Linq;
using Sources.Services.CoroutineRunnerServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Services.SceneLoaderServices
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private const string EmptySceneName = "Empty";
        private readonly CoroutineContext _coroutineContext;

        public SceneLoaderService()
        {
            _coroutineContext = new CoroutineContext();
        }

        public void LoadEmptyScene(Action onComplete = null) => 
            LoadScene(EmptySceneName, onComplete);

        public void LoadScene<T>(string scene, Action<T> onComplete = null, 
            LoadSceneMode loadSceneMode = LoadSceneMode.Single) where T : ISceneContext
        {
            LoadScene(scene, () =>
            {
                T sceneContext = GameObject.FindObjectsOfType<SceneContext>()
                    .Select(sc => sc.gameObject.GetComponent<T>())
                    .First(sc => sc != null);
                
                onComplete?.Invoke(sceneContext);
            }, loadSceneMode);
        }

        public void LoadScene(string scene, Action onComplete = null,
            LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(scene, loadSceneMode);
            _coroutineContext.RunNextFrame(onComplete);
        }

        public void UnloadScene(string scene, Action onCompleted = null) 
        {
            AsyncOperation loader = SceneManager.UnloadSceneAsync(scene);
            _coroutineContext.RunWhen(() => loader.isDone, onCompleted);
        }
    }
}