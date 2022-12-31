using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Bootstrap
{
    public class SceneData : MonoBehaviour
    {
#if UNITY_EDITOR
        private static bool s_isGameStarted;
        
        private void Awake()
        {
            if (!s_isGameStarted)
            {
                s_isGameStarted = true;
                
                if (SceneManager.GetActiveScene().buildIndex != 0)
                    SceneManager.LoadScene(0);
            }
        }
#endif
    }
}