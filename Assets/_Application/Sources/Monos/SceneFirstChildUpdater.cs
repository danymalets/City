#if UNITY_EDITOR

using UnityEngine;

namespace Sources.App.Infrastructure.Bootstrap
{
    [ExecuteInEditMode]
    public class SceneFirstChildUpdater : MonoBehaviour
    {
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
    }
}

#endif