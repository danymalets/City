using UnityEngine;

namespace Sources.Services.SceneLoader
{
#if UNITY_EDITOR
    [RequireComponent(typeof(EntryPointSceneStarter))]
    [RequireComponent(typeof(SceneFirstChildUpdater))]
#endif
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        
    }
}