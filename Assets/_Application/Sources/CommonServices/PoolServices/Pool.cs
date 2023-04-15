using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.CommonServices.PoolServices
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

        public IEnumerable<IRespawnable> Initialize()
        {
            for (int i = 0; i < _config.Size; i++)
                yield return CreateNew();
        }

        public T Get<T>(Transform parent, Vector3 position, Quaternion rotation)
            where T : IRespawnable
        {
            _instanceCount++;
            _maxInstance = Math.Max(_maxInstance, _instanceCount);

            if (IsNoFreeObjects)
            {
                Debug.LogWarning($"There are too few {_config.Prefab.RespawnableBehaviour.name} objects in the pool");
                CreateNew();
            }

            RespawnableBehaviour respawnableBehaviour = _freeObjects.Pop();

            respawnableBehaviour.transform.SetParent(parent);
            respawnableBehaviour.transform.localPosition = position;
            respawnableBehaviour.transform.localRotation = rotation;
            respawnableBehaviour.gameObject.SetActive(true);

            return respawnableBehaviour is T respawnable ? respawnable : throw new InvalidOperationException();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private IRespawnable CreateNew()
        {
            RespawnableBehaviour respawnableBehaviour = Instantiate(_config.Prefab.RespawnableBehaviour, transform);

            respawnableBehaviour.transform.SetParent(transform);
            respawnableBehaviour.gameObject.SetActive(false);
            
            _freeObjects.Push(respawnableBehaviour);

            return respawnableBehaviour;
        }

        public void OnDespawned(RespawnableBehaviour respawnableBehaviour)
        {
            _instanceCount--;

            respawnableBehaviour.gameObject.SetActive(false);
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