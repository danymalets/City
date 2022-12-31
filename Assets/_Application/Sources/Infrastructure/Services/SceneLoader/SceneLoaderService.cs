using System;
using System.Collections;
using Sources.Infrastructure.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Services.SceneLoader
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private readonly ICoroutineRunnerService _coroutineRunner;

        public SceneLoaderService()
        {
            _coroutineRunner = DiContainer.Resolve<ICoroutineRunnerService>();
        }

        public void LoadSceneInOneFrame(string sceneName, Action onComplete = null) =>
            _coroutineRunner.StartCoroutine(LoadSceneInOneFrameCoroutine(sceneName, onComplete));

        public IEnumerator LoadSceneInOneFrameCoroutine(string sceneName, Action onComplete = null)
        {
            SceneManager.LoadScene(sceneName);
            yield return null;
            onComplete?.Invoke();
        }
            
        public void LoadScene(string sceneName, Action onComplete = null) =>
            LoadScene(sceneName, null, onComplete);

        public void LoadScene(string sceneName, Action<float> onProgressChanged, Action onComplete) => 
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, onProgressChanged, onComplete));

        private IEnumerator LoadSceneCoroutine(
            string sceneIndex, 
            Action<float> onProgressChanged, 
            Action onComplete)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {
                onProgressChanged?.Invoke(operation.progress);
                yield return null;
            }

            yield return null;

            onComplete?.Invoke();
        }
    }
}