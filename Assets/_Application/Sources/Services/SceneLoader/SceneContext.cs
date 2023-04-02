using Sources.Data;
using UnityEngine;

namespace Sources.Monos
{
#if UNITY_EDITOR
    [RequireComponent(typeof(EntryPointSceneStarter))]
    [RequireComponent(typeof(SceneFirstChildUpdater))]
#endif
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        
    }
}