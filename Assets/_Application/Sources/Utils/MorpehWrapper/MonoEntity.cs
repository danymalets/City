using _Application.Sources.CommonServices.PoolServices;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper
{
    public abstract class MonoEntity : RespawnableBehaviour, IMonoEntity
    {
        [ReadOnly]
        [SerializeField]
        private PhysicsEventsReceiver[] _collisionsReceivers;
        
        public void Setup(Entity entity)
        {
            foreach (PhysicsEventsReceiver eventsReceiver in _collisionsReceivers) 
                eventsReceiver.Entity = entity;
        }
        
        public void Cleanup()
        {
            foreach (PhysicsEventsReceiver eventsReceiver in _collisionsReceivers) 
                eventsReceiver.Entity = null;
        }
        
        protected virtual void OnValidate()
        {
            _collisionsReceivers = GetComponentsInChildren<PhysicsEventsReceiver>();
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