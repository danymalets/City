using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Services.InstantiatorServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.PoolServices
{
    public class PoolGroup
    {
        private Transform _poolRoot;
        private Transform _groupRoot;
        private RespawnableBehaviour _prefab;
        private Stack<RespawnableBehaviour> _stack = new();
        private readonly int _initCount;
        private int _createdCount;
        private readonly IGameObjectService _gameObjectService;
        private readonly Transform _forceGroupRoot;

        public event Action<RespawnableBehaviour, PoolGroup> ObjectInstantiated;
        public event Action<RespawnableBehaviour, PoolGroup> ObjectDestroyed;

        public PoolGroup(Transform poolRoot, RespawnableBehaviour prefab, int initCount, Transform forceGroupRoot = null)
        {
            _gameObjectService = DiContainer.Resolve<IGameObjectService>();
            
            _poolRoot = poolRoot;
            _prefab = prefab;
            _initCount = initCount;
            _forceGroupRoot = forceGroupRoot;
        }

        public void Initialize()
        {
            _groupRoot = 
                _forceGroupRoot == null ? 
                _gameObjectService.CreateEmptyObject($"{_prefab.name} - PoolGroup", _poolRoot) : 
                _forceGroupRoot;
            
            for (int i = 0; i < _initCount; i++)
            {
                CreateNewAndPush();
            }
        }

        private RespawnableBehaviour CreateNewAndPush()
        {
            RespawnableBehaviour respawnable = _gameObjectService.Instantiate(_prefab, _groupRoot);
            respawnable.gameObject.Disable();
            _stack.Push(respawnable);
            ObjectInstantiated?.Invoke(respawnable, this);
            _createdCount++;
            return respawnable;
        }

        public RespawnableBehaviour Get()
        {
            if (_stack.IsEmpty())
            {
                Debug.LogWarning($"Pool {_prefab.gameObject.name} is too small. New object instantiated.");
                CreateNewAndPush(); // todo: send to service info 
            }

            RespawnableBehaviour respawnable = _stack.Pop();
            respawnable.gameObject.Enable();
            return respawnable;
        }

        public void Return(RespawnableBehaviour respawnableBehaviour)
        {
            respawnableBehaviour.transform.SetParent(_groupRoot);
            respawnableBehaviour.transform.localPosition = Vector3.zero;
            respawnableBehaviour.transform.localRotation = Quaternion.identity;
            respawnableBehaviour.gameObject.Disable();
            _stack.Push(respawnableBehaviour);
        }

        public void Cleanup()
        {
            Debug.Assert(_createdCount == _stack.Count, 
                "Cannot cleanup pool group. Not all objects returned.");
            
            foreach (RespawnableBehaviour respawnable in _stack)
            {
                _gameObjectService.Destroy(respawnable.gameObject);
                ObjectDestroyed?.Invoke(respawnable, this);
            }
            
            _gameObjectService.Destroy(_groupRoot.gameObject);
        }
    }
}