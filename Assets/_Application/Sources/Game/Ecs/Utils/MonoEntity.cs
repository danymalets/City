using System;
using Leopotam.Ecs;
using Sources.Infrastructure.Services.Pool;
using UnityEngine;

namespace Sources.Game.Ecs.Utils
{
    public class MonoEntity : RespawnableBehaviour
    {
        [SerializeField]
        private MonoComponentBase[] _viewComponents;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _viewComponents = GetComponents<MonoComponentBase>();
        }
#endif

        public void Setup(EcsEntity entity)
        {
            foreach (MonoComponentBase viewComponent in _viewComponents)
            {
                viewComponent.Setup(entity);
            }
        }
    }
}