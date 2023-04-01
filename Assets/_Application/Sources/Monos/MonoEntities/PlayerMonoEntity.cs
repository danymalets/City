using Sirenix.OdinInspector;
using Sources.Data.Constants;
using Sources.Monos.Components.Monos;
using Sources.MonoViews.MonoViews;
using Sources.Utils.DMorpeh;
using Sources.Utils.DMorpeh.DefaultComponents.Monos;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace Sources.Monos.MonoEntities
{
    [RequireComponent(typeof(EnableableGameObject))]
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public partial class PlayerMonoEntity : MonoEntity
    {
        [SerializeField]
        private EnableableGameObject _enableableGameObject;

        [SerializeField]
        private SafeTransform _transform;

        [SerializeField]
        private RigidbodySwitcher _rigidbodySwitcher;

        [SerializeField]
        private PlayerBorders _playerBorders;

        [SerializeField]
        private SafeAnimator _animator;

        public IEnableableGameObject EnableableGameObject => _enableableGameObject;
        public IRigidbodySwitcher RigidbodySwitcher => _rigidbodySwitcher;
        public ITransform Transform => _transform;
        public IPlayerBorders PlayerBorders => _playerBorders;
        public IAnimator Animator => _animator;

#if UNITY_EDITOR
        [Button("Bake", ButtonSizes.Large)]
        private void Bake()
        {
            base.OnValidate();

            _transform = GetComponent<SafeTransform>();
            _enableableGameObject = GetComponent<EnableableGameObject>();
            _rigidbodySwitcher = GetComponent<RigidbodySwitcher>();
            _playerBorders = GetComponentInChildren<PlayerBorders>();
            _animator = GetComponentInChildren<SafeAnimator>();
            
            _playerBorders.SafeCapsuleCollider.Layer = Layers.Player;
        }
#endif
    }
}