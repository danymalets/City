using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Services.PoolServices
{
    public partial class PoolService : IPoolCreatorService, IPoolSpawnerService, IPoolDespawnerService
    {
        private List<PoolConfig> _poolConfigs;
        
        private readonly Dictionary<RespawnableBehaviour, PoolGroup> _poolGroups = new();
        private readonly Dictionary<RespawnableBehaviour, RespawnableBehaviour> _prefabsRefs = new();
        private readonly Transform _poolRoot;
        
        public PoolService(Transform poolRoot)
        {
            _poolRoot = poolRoot;
        }

        public void CreatePool(PoolConfig poolConfig)
        {
            PoolGroup poolGroup = new(_poolRoot, poolConfig.Prefab, poolConfig.Size, poolConfig.ForceParent);

            foreach (RespawnableBehaviour respawnable in poolGroup.Initialize())
            {
                _prefabsRefs.Add(respawnable, poolConfig.Prefab);
            }

            if (_poolGroups.ContainsKey(poolConfig.Prefab))
                throw new InvalidOperationException($"{poolConfig.Prefab.gameObject.name} has been added");
            
            _poolGroups.Add(poolConfig.Prefab, poolGroup);
        }

        public void CleanupPool(RespawnableBehaviour respawnable)
        {
            _poolGroups[respawnable].Cleanup();
            _poolGroups.Remove(respawnable);
        }

        public T Spawn<T>(T prefab) where T : RespawnableBehaviour
        {
            if (_poolGroups.TryGetValue(prefab, out PoolGroup pool))
            {
                RespawnableBehaviour t = pool.Get();
                T respawnable = t as T;
                return respawnable;
            }
            else
            {
                throw new InvalidOperationException($"{prefab} pool not exists");
            }
        }

        public void Despawn<T>(T instance) where T : RespawnableBehaviour
        {
            RespawnableBehaviour prefab = _prefabsRefs[instance];
            _poolGroups[prefab].Return(instance);
        }
    }
}