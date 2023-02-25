using System;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarBorder;
using Sources.Game.Ecs.Components.Views.CarCollider;
using Sources.Game.Ecs.Components.Views.EnableDisable;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Components.Views.PlayerAnimators;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TransformComponent))]
    [RequireComponent(typeof(EnableableEntity))]
    [RequireComponent(typeof(PhysicBody))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerColliders))]
    [RequireComponent(typeof(EntityBorders))]
    [RequireComponent(typeof(PlayerData))]
    public class PlayerMonoEntity : MonoEntity
    {
        [SerializeField]
        private TransformComponent _transform;

        [SerializeField]
        private PhysicBody _physicBody;

        [SerializeField]
        private PlayerColliders _playerColliders;

        [SerializeField]
        private EntityBorders _entityBorders;

        [SerializeField]
        private PlayerAnimator _playerAnimator;

        [SerializeField]
        private PlayerData _playerData;

        [FormerlySerializedAs("_enableDisableEntity")]
        [SerializeField]
        private EnableableEntity _enableableEntity;
        
        private void OnValidate()
        {
            _transform = GetComponent<TransformComponent>();
            _physicBody = GetComponent<PhysicBody>();
            _playerColliders = GetComponent<PlayerColliders>();
            _entityBorders = GetComponent<EntityBorders>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerData = GetComponent<PlayerData>();
            _enableableEntity = GetComponent<EnableableEntity>();
        }

        protected override void OnSetup()
        {
            Entity.SetMono<ITransform>(_transform);
            Entity.SetMono<IEntityBorders>(_entityBorders);
            Entity.SetMono<IPlayerColliders>(_playerColliders);
            Entity.SetMono<IPhysicBody>(_physicBody);
            Entity.SetMono<IPlayerAnimator>(_playerAnimator);
            Entity.SetMono<IPlayerData>(_playerData);
            Entity.SetMono<IEnableableEntity>(_enableableEntity);

            _playerAnimator.transform.localScale = Vector3.one * 0.92f;
            _playerColliders.Setup(Entity);
            _physicBody.Setup();
            _playerAnimator.Setup();
            
            // Entity.GetMono<IPhysicBody>().IsKinematic = true;
            // Entity.GetMono<IPhysicBody>().DetectCollisions = false;
        }

        protected override void OnCleanup()
        {
            _playerColliders.Cleanup();
        }

        public Vector3 Center => _entityBorders.Center;
        public Vector3 HalfExtents => _entityBorders.HalfExtents;
    }
}