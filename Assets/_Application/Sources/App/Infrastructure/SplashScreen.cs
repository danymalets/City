using System;
using System.Collections;
using Sources.Services.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.App
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