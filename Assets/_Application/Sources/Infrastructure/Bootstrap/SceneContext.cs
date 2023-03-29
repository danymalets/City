using System;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
#if UNITY_EDITOR
    [RequireComponent(typeof(EntryPointSceneStarter))]
    [RequireComponent(typeof(SceneFirstChildUpdater))]
#endif
    public class SceneContext : MonoBehaviour
    {
        
    }
}