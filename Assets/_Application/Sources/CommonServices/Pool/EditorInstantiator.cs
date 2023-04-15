using UnityEngine;

namespace Sources.Services.Pool
{
    public class EditorInstantiator
    {
        public static T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent)
            where T : class, IRespawnable
        {
            return GameObject.Instantiate(prefab.RespawnableBehaviour, position, rotation, parent) as T;
        }

        public static void Destroy<T>(T obj)
            where T : class, IRespawnable
        {
            GameObject.Destroy(obj.RespawnableBehaviour);
        }
    }
}