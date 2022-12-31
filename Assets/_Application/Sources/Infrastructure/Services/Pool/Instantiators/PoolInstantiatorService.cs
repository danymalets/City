using UnityEngine;

namespace Sources.Infrastructure.Services.Pool.Instantiators
{
    public class PoolInstantiatorService : IPoolInstantiatorService
    {
        private readonly IPoolService _pool;

        public PoolInstantiatorService()
        {
            _pool = DiContainer.Resolve<IPoolService>();
        }

        public T Instantiate<T>(T prefab)
            where T : RespawnableBehaviour => 
            _pool.Get(prefab);

        public T Instantiate<T>(T prefab, Vector3 at)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = _pool.Get(prefab);
            respawnableBehaviour.transform.position = at;
            return respawnableBehaviour;
        }

        public T Instantiate<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = _pool.Get(prefab);
            respawnableBehaviour.transform.position = at;
            respawnableBehaviour.transform.rotation = rotation;
            return respawnableBehaviour;
        }

        public T Instantiate<T>(T prefab, Transform parent, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = _pool.Get(prefab);
            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = at;
            respawnableBehaviour.transform.localRotation = rotation;
            return respawnableBehaviour;
        }

        public T Instantiate<T>(T prefab, Transform parent)
            where T: RespawnableBehaviour
        {
            T respawnableBehaviour = _pool.Get(prefab);
            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = Vector3.zero;
            return respawnableBehaviour;
        }
    }
}