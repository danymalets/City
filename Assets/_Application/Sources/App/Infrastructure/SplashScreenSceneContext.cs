using System.Collections;
using Sources.Services.SceneLoaderServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure
{
    public class SplashScreenSceneContext : SceneContext
    {
        private IEnumerator Start()
        {
            // yield return null;
            yield return new WaitForSecondsRealtime(5f);
            SceneManager.LoadScene(1);
        }
    }
}