using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.Points;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities
{
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public class PropsMonoEntity : MonoEntity, IPropsMonoEntity, IMonoEntity
    {
        [SerializeField]
        private PropsMonoEntity[] _derivedProps;

        [SerializeField]
        private float _mass = 50;

        [SerializeField]
        private SafeColliderBase[] _colliders;

        [SerializeField]
        private RigidbodySwitcher _rigidbodySwitcher;
        
        [SerializeField]
        private SafeTransform _safeTransform;

        [SerializeField]
        private MonoPoint _centerOfMassPoint;

        [SerializeField]
        private bool _isVertical;

        [FormerlySerializedAs("_topPoint")]
        [ShowIf(nameof(_isVertical))]
        [SerializeField]
        private MonoPoint _supportPoint;


        public IEnumerable<IPropsMonoEntity> DerivedProps => _derivedProps;
        public IRigidbodySwitcher RigidbodySwitcher => _rigidbodySwitcher;
        public float Mass => _mass;
        public IEnumerable<ICollider> Colliders => _colliders;
        public ITransform Transform => _safeTransform;
        public IPoint CenterOfMassPoint => _centerOfMassPoint;
        public bool IsVertical => _isVertical;
        public IPoint VerticalPoint => _supportPoint;

        [Button("Force Validate", ButtonSizes.Large)]
        protected override void OnValidate()
        {
            base.OnValidate();
            _colliders = GetComponentsInChildren<SafeColliderBase>();
            _safeTransform = GetComponent<SafeTransform>();
            _rigidbodySwitcher = GetComponent<RigidbodySwitcher>();
        }
    }
}