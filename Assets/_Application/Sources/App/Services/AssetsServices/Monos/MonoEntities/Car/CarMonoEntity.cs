using System.Collections.Generic;
using Sources.App.Data.Cars;
using Sources.App.Services.AssetsServices.Monos.Cars;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Car
{
    [RequireComponent(typeof(EnableableGameObject))]
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public partial class CarMonoEntity : MonoEntity
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
    }
}