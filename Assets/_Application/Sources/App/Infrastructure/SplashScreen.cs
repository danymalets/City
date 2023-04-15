using System.Collections;
using _Application.Sources.CommonServices.SceneLoaderServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Application.Sources.App.Infrastructure
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