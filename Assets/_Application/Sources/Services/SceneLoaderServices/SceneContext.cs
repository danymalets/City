using UnityEngine;

namespace Sources.Services.SceneLoaderServices
{
    [RequireComponent(typeof(EntryPointSceneStarter))]
    [RequireComponent(typeof(SceneFirstChildUpdater))]
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        
    }
}