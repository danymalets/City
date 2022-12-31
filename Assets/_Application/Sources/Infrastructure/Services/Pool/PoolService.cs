using System.Collections.Generic;
using UnityEngine;

namespace Sources.Infrastructure.Services.Pool
{
    public class PoolService : MonoBehaviour, IPoolService
    {
        private List<PoolConfig> _poolConfigs;
        
        private readonly Dictionary<RespawnableBehaviour, Pool> _pools =
            new Dictionary<RespawnableBehaviour, Pool>();

        public T Get<T>(T prefab) where T : RespawnableBehaviour
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

        public Pool CreatePool(PoolConfig poolConfig)
        {
            Pool pool = new GameObject($"{poolConfig.Prefab.name} Pool").AddComponent<Pool>();
            pool.transform.SetParent(transform);

            pool.Setup(poolConfig);
            pool.Initialize();
            
            _pools.Add(poolConfig.Prefab, pool);

            return pool;
        }

        public void DestroyPool(RespawnableBehaviour respawnable)
        {
            _pools[respawnable].Destroy();
            _pools.Remove(respawnable);
        }
    }
}