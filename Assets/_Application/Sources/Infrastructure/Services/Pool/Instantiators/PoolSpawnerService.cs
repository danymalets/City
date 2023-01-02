using UnityEngine;

namespace Sources.Infrastructure.Services.Pool.Instantiators
{
    public class PoolSpawnerService : IPoolSpawnerService
    {
        private readonly IPoolCreatorService _poolCreator;

        public PoolSpawnerService()
        {
            _poolCreator = DiContainer.Resolve<IPoolCreatorService>();
        }

        public T Spawn<T>(T prefab)
            where T : RespawnableBehaviour => 
            _poolCreator.Get(prefab);

        public T Spawn<T>(T prefab, Vector3 at)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = _poolCreator.Get(prefab);
            respawnableBehaviour.transform.position = at;
            return respawnableBehaviour;
        }

        public T Spawn<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = _poolCreator.Get(prefab);
            respawnableBehaviour.transform.position = at;
            respawnableBehaviour.transform.rotation = rotation;
            return respawnableBehaviour;
        }

        public T Spawn<T>(T prefab, Transform parent, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = _poolCreator.Get(prefab);
            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = at;
            respawnableBehaviour.transform.localRotation = rotation;
            return respawnableBehaviour;
        }

        public T Spawn<T>(T prefab, Transform parent)
            where T: RespawnableBehaviour
        {
            T respawnableBehaviour = _poolCreator.Get(prefab);
            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = Vector3.zero;
            return respawnableBehaviour;
        }
    }
}