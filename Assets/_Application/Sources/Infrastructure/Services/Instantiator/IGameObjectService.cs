using UnityEngine;

namespace Sources.Infrastructure.Services
{
    public interface IGameObjectService : IService
    {
        Transform CreateEmptyObject(string name, Transform parent = null);
        
        T Instantiate<T>(T prefab, Vector3 at, Quaternion rotation) 
            where T: Object;

        T Instantiate<T>(T prefab) 
            where T: Object;

        T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) 
            where T : Object;

        T Instantiate<T>(T prefab, Transform parent)
            where T : Object;

        void DontDestroyOnLoad<T>(T obj)
            where T: Object;
    }
}