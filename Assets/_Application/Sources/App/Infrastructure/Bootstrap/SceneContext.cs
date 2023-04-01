using UnityEngine;

namespace Sources.App.Infrastructure.Bootstrap
{
#if UNITY_EDITOR
    [RequireComponent(typeof(EntryPointSceneStarter))]
    [RequireComponent(typeof(SceneFirstChildUpdater))]
#endif
    public class SceneContext : MonoBehaviour
    {
        
    }
}