using System;
using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services.Pool;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Utils
{
    public abstract class MonoEntity : RespawnableBehaviour, IEntityAccess
    {
        [ReadOnly]
        [SerializeField]
        private SafeColliderBase[] _allColliders;
        
        public Entity Entity { get; set; }

        public void Setup(Entity entity)
        {
            Entity = entity;
            foreach (SafeColliderBase safeColliderBase in _allColliders)
            {
                safeColliderBase.Entity = entity;
            }
            // OnSetup();
        }

        // protected abstract void OnSetup();

        public void Cleanup()
        {
            foreach (SafeColliderBase safeColliderBase in _allColliders)
            {
                safeColliderBase.Entity = null;
            }

            Entity = null;
            // OnCleanup();
        }

        // protected abstract void OnCleanup();

        protected virtual void OnValidate()
        {
            _allColliders = GetComponentsInChildren<SafeColliderBase>();
        }

        [Button("Make Safe", ButtonSizes.Large)]
        public void MakeSafe()
        {
            AddRequired<SafeBoxCollider, BoxCollider>();
            AddRequired<SafeCapsuleCollider, CapsuleCollider>();
            AddRequired<SafeAnimator, Animator>();
            AddRequired<SafeMeshRenderer, MeshRenderer>();
            AddRequired<SafeCamera, Camera>();
        }
        
        private void AddRequired<TRequired, TExist>()
            where TRequired : Component
            where TExist : Component
        {
            foreach (TExist component in GetComponentsInChildren<TExist>())
            {
                if (!component.HasComponent<TRequired>())
                    component.gameObject.AddComponent<TRequired>();
            }
        }
    }
}