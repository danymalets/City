using System;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarBorder;
using Sources.Game.Ecs.Components.Views.CarCollider;
using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TransformComponent))]
    [RequireComponent(typeof(PhysicBody))]
    [RequireComponent(typeof(EntityColliders))]
    [RequireComponent(typeof(EntityBorders))]
    [RequireComponent(typeof(CarWheels))]
    [RequireComponent(typeof(CarData))]
    public class CarMonoEntity : MonoEntity
    {
        [SerializeField]
        private TransformComponent _transform;

        [SerializeField]
        private PhysicBody _physicBody;

        [SerializeField]
        private EntityColliders _entityColliders;

        [SerializeField]
        private EntityBorders _entityBorders;

        [SerializeField]
        private CarWheels _carWheels;

        [SerializeField]
        private CarData _carData;

        private void OnValidate()
        {
            _transform = GetComponent<TransformComponent>();
            _physicBody = GetComponent<PhysicBody>();
            _entityColliders = GetComponent<EntityColliders>();
            _entityBorders = GetComponent<EntityBorders>();
            _carWheels = GetComponent<CarWheels>();
            _carData = GetComponent<CarData>();
        }

        protected override void OnSetup()
        {
            Entity.SetMono<ITransform>(_transform);
            Entity.SetMono<IEntityColliders>(_entityColliders);
            Entity.SetMono<IEntityBorders>(_entityBorders);
            Entity.SetMono<IPhysicBody>(_physicBody);
            Entity.SetMono<ICarWheels>(_carWheels);
            Entity.SetMono<ICarData>(_carData);
        }

        public Vector3 CenterRelatedRootPoint => _entityBorders.Center - RootOffset;
        public Vector3 HalfExtents => _entityBorders.HalfExtents;
        public Vector3 RootOffset => _carWheels.RootOffset;
    }
}