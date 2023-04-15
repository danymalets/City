using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Services.Pool
{
    public class PoolService : MonoBehaviour, IPoolCreatorService, IPoolSpawnerService, IPoolDespawnerService
    {
        private List<PoolConfig> _poolConfigs;
        
        private readonly Dictionary<IRespawnable, Pool> _pools = new();
        private readonly Dictionary<IRespawnable, IRespawnable> _prefabsRefs = new();
        
        public Pool CreatePool(PoolConfig poolConfig)
        {
            Pool pool = new GameObject($"{poolConfig.Prefab.RespawnableBehaviour.name} Pool").AddComponent<Pool>();
            pool.transform.SetParent(transform);

            pool.Setup(poolConfig);

            foreach (IRespawnable respawnable in pool.Initialize())
            {
                _prefabsRefs.Add(respawnable, poolConfig.Prefab);
            }

            if (_pools.ContainsKey(poolConfig.Prefab))
                throw new InvalidOperationException($"{poolConfig.Prefab.RespawnableBehaviour.gameObject.name} has been added");
            
            _pools.Add(poolConfig.Prefab, pool);

            return pool;
        }

        public void DestroyPool(IRespawnable respawnable)
        {
            _pools[respawnable].Destroy();
            _pools.Remove(respawnable);
        }

        public T Spawn<T>(T prefab)
            where T : IRespawnable => 
            Spawn(prefab, null, Vector3.zero, Quaternion.identity);

        public T Spawn<T>(T prefab, Vector3 at)
            where T : IRespawnable =>
            Spawn(prefab, null, at, Quaternion.identity);

        public T Spawn<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : IRespawnable =>
            Spawn(prefab, null, at, rotation);

        public T Spawn<T>(T prefab, Transform parent)
            where T : IRespawnable =>
            Spawn<T>(prefab, parent, Vector3.zero, Quaternion.identity);

        public T Spawn<T>(T prefab, Transform parent, Vector3 position, Quaternion rotation) where T : IRespawnable
        {
            if (_pools.TryGetValue(prefab, out Pool pool))
            {
                return pool.Get<T>(parent, position, rotation);
            }
            else
            {
                Debug.LogWarning($"{prefab} pool not exists");
                return CreatePool(new PoolConfig(prefab, 10)).Get<T>(parent, position, rotation);
            }
        }

        public void Despawn<T>(T instance) where T : IRespawnable
        {
            IRespawnable prefab = _prefabsRefs[instance];
            Pool pool = _pools[prefab];
            pool.OnDespawned(instance as RespawnableBehaviour ?? throw new InvalidOperationException());
        }
    }
}