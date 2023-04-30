#if UNITY_EDITOR

using Sources.Utils.CommonUtils.EditorTools;
using UnityEngine;

namespace Sources.CommonServices.PoolServices
{
    public static class EditorInstantiator
    {
        public static TMono InstantiateAsPrefab<T, TMono>(T prefab, Transform parent)
            where T : class, IRespawnable
            where TMono : MonoBehaviour, IRespawnable
        {
            return DEditor.InstantiatePrefab(prefab.RespawnableBehaviour, parent) as TMono;
        }

        public static void DestroyImmediate<T>(T obj)
            where T : class, IRespawnable
        {
            GameObject.DestroyImmediate(obj.RespawnableBehaviour);
        }
    }
}

#endif