using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.InstantiatorServices
{
    public interface IGameObjectService : IService
    {
        Transform CreateEmptyObject(string name, Transform parent = null);
        
        T Instantiate<T>(T prefab, Vector3 at, Quaternion rotation) 
            where T: MonoBehaviour;

        T Instantiate<T>(T prefab) 
            where T: MonoBehaviour;

        T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) 
            where T : MonoBehaviour;

        T Instantiate<T>(T prefab, Transform parent)
            where T : MonoBehaviour;

        void DontDestroyOnLoad(GameObject obj);
    }
}