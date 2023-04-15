using UnityEngine;

namespace Sources.CommonServices.SceneLoaderServices
{
#if UNITY_EDITOR
    [RequireComponent(typeof(EntryPointSceneStarter))]
    [RequireComponent(typeof(SceneFirstChildUpdater))]
#endif
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        
    }
}