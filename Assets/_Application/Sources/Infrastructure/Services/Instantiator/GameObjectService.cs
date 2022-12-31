using UnityEngine;

namespace Sources.Infrastructure.Services
{
    public class GameObjectService : IGameObjectService
    {
        public Transform CreateEmptyObject(string name, Transform parent = null)
        {
            Transform transform = (new GameObject(name)).transform;
            transform.SetParent(parent);
            return transform;
        }

        public T Instantiate<T>(T prefab) 
            where T: Object =>
            Object.Instantiate(prefab);

        public T Instantiate<T>(T prefab, Vector3 at, Quaternion rotation) 
            where T: Object =>
            Object.Instantiate(prefab, at, rotation);

        public T Instantiate<T>(T prefab, Transform parent)
            where T : Object =>
            Object.Instantiate(prefab, parent);

        public T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) 
            where T : Object =>
            Object.Instantiate(prefab, position, rotation, parent);

        public void DontDestroyOnLoad<T>(T obj)
            where T: Object =>
            Object.DontDestroyOnLoad(obj);
    }
}