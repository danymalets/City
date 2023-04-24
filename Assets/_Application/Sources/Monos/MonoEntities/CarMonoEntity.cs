using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.Monos.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Sources.Monos.MonoEntities
{
    [RequireComponent(typeof(EnableableGameObject))]
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public class CarMonoEntity : MonoEntity, ICarMonoEntity
    {
        [SerializeField]
        private EnableableGameObject _enableableGameObject;

        [SerializeField]
        private SafeTransform _transform;

        [SerializeField]
        private RigidbodySwitcher _rigidbodySwitcher;

        [SerializeField]
        private WheelsSystem _wheelsSystem;

        [SerializeField]
        private CarEnterPoints _enterPoints;

        [SerializeField]
        private CarBorders _carBorders;

        [SerializeField]
        private SafeColliderBase[] _colliders;

        [SerializeField]
        private SafeMeshRenderer[] _meshRenderers;

        [SerializeField]
        private CarObstacles _carObstacles;

        public IEnableableGameObject EnableableGameObject => _enableableGameObject;
        public IRigidbodySwitcher RigidbodySwitcher => _rigidbodySwitcher;
        public ITransform Transform => _transform;
        public IWheelsSystem WheelsSystem => _wheelsSystem;
        public ICarEnterPoints EnterPoints => _enterPoints;
        public ICarBorders BorderCollider => _carBorders;
        public IEnumerable<IEntityAccess> Colliders => _colliders;
        public IEnumerable<IMeshRenderer> MeshRenderers => _meshRenderers;

        private void Awake()
        {
            // foreach (SafeMeshRenderer meshRenderer in _meshRenderers) 
            //     meshRenderer.Material = new Material(meshRenderer.Material);
        }

        [Button("Bake", ButtonSizes.Large)]
        private void Bake()
        {
            base.OnValidate();

            _transform = GetComponent<SafeTransform>();
            _enableableGameObject = GetComponent<EnableableGameObject>();
            _rigidbodySwitcher = GetComponent<RigidbodySwitcher>();
            _wheelsSystem = GetComponentInChildren<WheelsSystem>();
            _enterPoints = GetComponentInChildren<CarEnterPoints>();
            _carBorders = GetComponentInChildren<CarBorders>();
            _meshRenderers = GetComponentsInChildren<SafeMeshRenderer>();
            _carObstacles = GetComponentInChildren<CarObstacles>();
            _colliders = GetComponentsInChildren<SafeColliderBase>()
                .ExceptOne(_carBorders.SafeBoxCollider).ToArray();
            
            _wheelsSystem.DisableSystem();

            foreach (SafeColliderBase collider in _colliders) 
                collider.Layer = Layers.Car;

            _carBorders.SafeBoxCollider.IsTrigger = true;
            _carBorders.SafeBoxCollider.Layer = Layers.CarBorders;
        }

        [Button("Set auto borders (do not use multi-click on this button)", ButtonSizes.Large)]
        private void SetAutoBorders() => 
            _carBorders.SetupBounds(_colliders);
        
        [Button("Set auto obstacles (do not use multi-click on this button)", ButtonSizes.Large)]
        private void SetAutoObstacles() => 
            _carObstacles.SetupBounds(_colliders);

        public Vector3 CenterRelatedRootPoint => _carBorders.SafeBoxCollider.BoxColliderData.Center - RootOffset;
        public Vector3 HalfExtents => _carBorders.SafeBoxCollider.BoxColliderData.HalfExtents;
        public Vector3 RootOffset => _wheelsSystem.RootOffset;
    }
}