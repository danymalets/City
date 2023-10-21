using UnityEngine;

namespace Sources.Services.InstantiatorServices
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
            where T : MonoBehaviour =>
            GameObject.Instantiate(prefab);

        public T Instantiate<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : MonoBehaviour =>
            GameObject.Instantiate(prefab, at, rotation);

        public T Instantiate<T>(T prefab, Transform parent)
            where T : MonoBehaviour =>
            GameObject.Instantiate(prefab, parent);

        public T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent)
            where T : MonoBehaviour =>
            GameObject.Instantiate(prefab, position, rotation, parent);

        public void DontDestroyOnLoad(GameObject obj) =>
            GameObject.DontDestroyOnLoad(obj);

        public void Destroy(GameObject obj) =>
            GameObject.Destroy(obj);

        public void DestroyChildren(Transform transform)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}