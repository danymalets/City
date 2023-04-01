#if UNITY_EDITOR


using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure.Bootstrap
{
    public class EntryPointSceneStarter : MonoBehaviour
    {
        private static bool s_isGameStarted;

        private void Awake()
        {
            if (!Application.isPlaying)
                return;
            
            if (!s_isGameStarted)
            {
                s_isGameStarted = true;
                
                if (SceneManager.GetActiveScene().buildIndex != 0)
                    SceneManager.LoadScene(0);
            }
        }
    }
}

#endif