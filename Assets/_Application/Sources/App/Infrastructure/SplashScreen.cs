using System.Collections;
using Sources.CommonServices.SceneLoaderServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure
{
    [RequireComponent(typeof(SceneFirstChildUpdater))]
    public class SplashScreen : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return null;
            SceneManager.LoadScene(1);
        }
    }
}