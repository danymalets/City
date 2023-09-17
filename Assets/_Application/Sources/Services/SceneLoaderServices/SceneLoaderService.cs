using System;
using System.Collections;
using Sources.Services.CoroutineRunnerServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Services.SceneLoaderServices
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private readonly CoroutineContext _coroutineContext;

        public SceneLoaderService()
        {
            _coroutineContext = new CoroutineContext();
        }

        public void LoadScene<T>(string scene, Action<T> onComplete = null)
            where T : ISceneContext
        {
            LoadScene(scene, () =>
            {
                T sceneContext = GameObject.FindObjectOfType<SceneContext>()
                    .gameObject.GetComponent<T>();
                
                DAssert.IsTrue(sceneContext != null);
            
                onComplete?.Invoke(sceneContext);
            });
        }

        public void LoadScene(string scene, Action onComplete = null)
        {
            SceneManager.LoadScene(scene);
            _coroutineContext.RunNextFrame(onComplete);
        }
    }
}