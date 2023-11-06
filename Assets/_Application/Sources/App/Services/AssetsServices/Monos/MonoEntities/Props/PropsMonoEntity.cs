using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.Points;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Props
{
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public partial class PropsMonoEntity : MonoEntity
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

        public IEnumerable<PropsMonoEntity> DerivedProps => _derivedProps;
        public IRigidbodySwitcher RigidbodySwitcher => _rigidbodySwitcher;
        public float Mass => _mass;
        public IEnumerable<ICollider> Colliders => _colliders;
        public ITransform Transform => _safeTransform;
        public IPoint CenterOfMassPoint => _centerOfMassPoint;
        public bool IsVertical => _isVertical;
        public IPoint VerticalPoint => _supportPoint;
    }
}