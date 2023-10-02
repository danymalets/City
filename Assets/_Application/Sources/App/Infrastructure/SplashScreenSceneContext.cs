using System.Collections;
using Sources.Services.SceneLoaderServices;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure
{
    public class SplashScreenSceneContext : SceneContext
    {
        private IEnumerator Start()
        {
            yield return null;
            SceneManager.LoadScene(1);
        }
    }
}