using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Services.PoolServices
{
    public partial class PoolService : IPoolCreatorService, IPoolSpawnerService, IPoolDespawnerService
    {
        private List<PoolConfig> _poolConfigs;
        
        private readonly Dictionary<RespawnableBehaviour, PoolGroup> _poolGroups = new();
        private readonly Transform _poolRoot;
        
        public PoolService(Transform poolRoot)
        {
            _poolRoot = poolRoot;
        }

        public void CreatePool(PoolConfig poolConfig)
        {
            PoolGroup poolGroup = new(_poolRoot, poolConfig.Prefab, poolConfig.Size, poolConfig.ForceParent);

            poolGroup.ObjectInstantiated += PoolGroup_OnObjectInstantiated;
            poolGroup.ObjectDestroyed += PoolGroup_OnObjectDestroyed;
            poolGroup.Initialize();

            if (_poolGroups.ContainsKey(poolConfig.Prefab))
                throw new InvalidOperationException($"{poolConfig.Prefab.gameObject.name} has been added");
            
            _poolGroups.Add(poolConfig.Prefab, poolGroup);
        }
        
        public void CleanupPool(RespawnableBehaviour respawnable)
        {
            PoolGroup group = _poolGroups[respawnable];
            group.Cleanup();
            group.ObjectInstantiated -= PoolGroup_OnObjectInstantiated;
            group.ObjectDestroyed -= PoolGroup_OnObjectDestroyed;
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
            PoolGroup group = _poolGroups[instance];
            group.Return(instance);
        }
        
        private void PoolGroup_OnObjectInstantiated(RespawnableBehaviour respawnable, PoolGroup group)
        {
            _poolGroups[respawnable] = group;
        }

        private void PoolGroup_OnObjectDestroyed(RespawnableBehaviour respawnable, PoolGroup group)
        {
            _poolGroups.Remove(respawnable);
        }
    }
}