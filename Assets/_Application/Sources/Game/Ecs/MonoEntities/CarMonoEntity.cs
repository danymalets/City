using System;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarBorder;
using Sources.Game.Ecs.Components.Views.CarCollider;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Components.Views.CarEnterPointsData;
using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TransformComponent))]
    [RequireComponent(typeof(PhysicBody))]
    [RequireComponent(typeof(CarColliders))]
    [RequireComponent(typeof(EntityBorders))]
    [RequireComponent(typeof(CarEnterPoints))]
    [RequireComponent(typeof(CarWheels))]
    [RequireComponent(typeof(CarData))]
    public class CarMonoEntity : MonoEntity
    {
        [SerializeField]
        private TransformComponent _transform;

        [SerializeField]
        private PhysicBody _physicBody;

        [SerializeField]
        private CarColliders _carColliders;

        [SerializeField]
        private EntityBorders _entityBorders;

        [SerializeField]
        private CarEnterPoints _carEnterPoints;

        [SerializeField]
        private CarWheels _carWheels;

        [SerializeField]
        private CarData _carData;

        private void OnValidate()
        {
            _transform = GetComponent<TransformComponent>();
            _physicBody = GetComponent<PhysicBody>();
            _carColliders = GetComponent<CarColliders>();
            _entityBorders = GetComponent<EntityBorders>();
            _carEnterPoints = GetComponent<CarEnterPoints>();
            _carWheels = GetComponent<CarWheels>();
            _carData = GetComponent<CarData>();
        }

        private void Awake()
        {
            _physicBody.CenterMass = _entityBorders.Center.WithY(_entityBorders.HalfExtents.y * 2f / 3f);
        }

        protected override void OnSetup()
        {
            Entity.SetMono<ITransform>(_transform);
            Entity.SetMono<IPhysicBody>(_physicBody);
            Entity.SetMono<ICarColliders>(_carColliders);
            Entity.SetMono<IEntityBorders>(_entityBorders);
            Entity.SetMono<ICarEnterPoints>(_carEnterPoints);
            Entity.SetMono<ICarWheels>(_carWheels);
            Entity.SetMono<ICarData>(_carData);
        }

        protected override void OnCleanup()
        {
        }

        public Vector3 CenterRelatedRootPoint => _entityBorders.Center - RootOffset;
        public Vector3 HalfExtents => _entityBorders.HalfExtents;
        public Vector3 RootOffset => _carWheels.RootOffset;
    }
}