using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Infrastructure.Services.Pool
{
    public class PoolService : MonoBehaviour, IPoolCreatorService, IPoolSpawnerService
    {
        private List<PoolConfig> _poolConfigs;
        
        private readonly Dictionary<RespawnableBehaviour, Pool> _pools = new();

        public Pool CreatePool(PoolConfig poolConfig)
        {
            Pool pool = new GameObject($"{poolConfig.Prefab.name} Pool").AddComponent<Pool>();
            pool.transform.SetParent(transform);

            pool.Setup(poolConfig);
            pool.Initialize();

            if (_pools.ContainsKey(poolConfig.Prefab))
                throw new InvalidOperationException($"{poolConfig.Prefab.gameObject.name} has been added");
            
            _pools.Add(poolConfig.Prefab, pool);

            return pool;
        }

        public void DestroyPool(RespawnableBehaviour respawnable)
        {
            _pools[respawnable].Destroy();
            _pools.Remove(respawnable);
        }

        public T Spawn<T>(T prefab)
            where T : RespawnableBehaviour => 
            Get(prefab);

        public T Spawn<T>(T prefab, Vector3 at)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = Get(prefab);
            respawnableBehaviour.transform.position = at;
            return respawnableBehaviour;
        }

        public T Spawn<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = Get(prefab);
            respawnableBehaviour.transform.position = at;
            respawnableBehaviour.transform.rotation = rotation;
            return respawnableBehaviour;
        }

        public T Spawn<T>(T prefab, Transform parent, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnableBehaviour = Get(prefab);
            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = at;
            respawnableBehaviour.transform.localRotation = rotation;
            return respawnableBehaviour;
        }

        public T Spawn<T>(T prefab, Transform parent)
            where T: RespawnableBehaviour
        {
            T respawnableBehaviour = Get(prefab);
            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = Vector3.zero;
            return respawnableBehaviour;
        }
        private T Get<T>(T prefab) where T : RespawnableBehaviour
        {
            if (_pools.TryGetValue(prefab, out Pool pool))
            {
                return (T)pool.Get();
            }
            else
            {
                Debug.LogWarning($"{prefab} pool not exists");
                return (T)CreatePool(new PoolConfig(prefab, 10)).Get();
            }
        }
    }
}