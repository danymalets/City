using UnityEngine;

namespace Sources.Services.SceneLoaderServices
{
    [ExecuteInEditMode]
    public class SceneFirstChildUpdater : MonoBehaviour
    {
#if UNITY_EDITOR
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
#endif
    }
}