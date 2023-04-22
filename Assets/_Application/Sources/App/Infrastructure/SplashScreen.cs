using System.Collections;
using Sources.CommonServices.SceneLoaderServices;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure
{
    public class SplashScreen : SceneContext
    {
        private IEnumerator Start()
        {
            yield return null;
            SceneManager.LoadScene(1);
        }
    }
}