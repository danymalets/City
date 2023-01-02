using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Bootstrap
{
    [ExecuteInEditMode]
    public class SceneContext : MonoBehaviour
    {
#if UNITY_EDITOR
        private static bool s_isGameStarted;
        
        protected virtual void Awake()
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

        private void Update()
        {
            if (Application.isPlaying)
                return;

            if (transform.parent != null)
                transform.SetParent(null);
            
            int index = transform.GetSiblingIndex();
            if (index != 0)
                transform.SetSiblingIndex(0);
        }
#else
        protected virtual void Awake()
        {
            
        }
#endif
    }
}