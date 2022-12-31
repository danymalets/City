using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Infrastructure.Services.Pool
{
    public partial class Pool : MonoBehaviour
    {
        private PoolConfig _config;
        
        private readonly Stack<RespawnableBehaviour> _freeObjects =
            new Stack<RespawnableBehaviour>();

        private int _maxInstance = 0;
        private int _instanceCount;

        public void Setup(PoolConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            for (int i = 0; i < _config.Size; i++) 
                CreateNew();
        }

        public RespawnableBehaviour Get()
        {
            _instanceCount++;
            _maxInstance = Math.Max(_maxInstance, _instanceCount);
            
            if (IsNoFreeObjects)
            {
                Debug.LogWarning($"There are too few {_config.Prefab.name} objects in the pool");
                CreateNew();
            }

            RespawnableBehaviour respawnableBehaviour = _freeObjects.Pop();
            
            respawnableBehaviour.transform.SetParent(null);
            respawnableBehaviour.transform.position = Vector3.zero;
            respawnableBehaviour.gameObject.SetActive(true);

            return respawnableBehaviour;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void CreateNew()
        {
            RespawnableBehaviour respawnableBehaviour = Instantiate(_config.Prefab, transform);
            
            respawnableBehaviour.transform.SetParent(transform);
            respawnableBehaviour.gameObject.SetActive(false);

            respawnableBehaviour.Despawned += OnDespawned;

            _freeObjects.Push(respawnableBehaviour);
        }

        private void OnDespawned(RespawnableBehaviour respawnableBehaviour)
        {
            _instanceCount--;
            
            respawnableBehaviour.transform.SetParent(transform);
            respawnableBehaviour.transform.localPosition = Vector3.zero;

            _freeObjects.Push(respawnableBehaviour);
        }

        private void OnDestroy()
        {
            //Debug.Log($"\"{_config.Prefab.name}\" max instance in one time = {_maxInstance}");
        }

        private bool IsNoFreeObjects => _freeObjects.Count == 0;
    }
}