using System;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarBorder;
using Sources.Game.Ecs.Components.Views.CarCollider;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(TransformComponent))]
    [RequireComponent(typeof(PhysicBody))]
    [RequireComponent(typeof(CarColliders))]
    [RequireComponent(typeof(CarBorders))]
    [RequireComponent(typeof(CarWheels))]
    [RequireComponent(typeof(CarData))]
    public class CarMonoEntity : MonoEntity
    {
        [SerializeField]
        private TransformComponent _transform;
        [FormerlySerializedAs("_carEngine")]
        [SerializeField]
        private CarWheels _carWheels;
        [SerializeField]
        private PhysicBody _physicBody;
        [SerializeField]
        private CarData _carData;
        [SerializeField]
        private CarBorders _carBorders;
        [SerializeField]
        private CarColliders _carColliders;

        private void OnValidate()
        {
            _transform = GetComponent<TransformComponent>();
            _carWheels = GetComponent<CarWheels>();
            _carBorders = GetComponent<CarBorders>();
            _carColliders = GetComponent<CarColliders>();
            _carData = GetComponent<CarData>();
            _physicBody = GetComponent<PhysicBody>();
        }

        protected override void OnSetup()
        {
            Entity.SetMono<ITransform>(_transform);
            Entity.SetMono<ICarWheels>(_carWheels);
            Entity.SetMono<ICarBorders>(_carBorders);
            Entity.SetMono<ICarColliders>(_carColliders);
            Entity.SetMono<ICarData>(_carData);
            Entity.SetMono<IPhysicBody>(_physicBody);
        }

        public Vector3 CenterRelatedRootPoint => _carBorders.Center - RootOffset;
        public Vector3 HalfExtents => _carBorders.HalfExtents;
        public Vector3 RootOffset => _carWheels.RootOffset;
    }
}