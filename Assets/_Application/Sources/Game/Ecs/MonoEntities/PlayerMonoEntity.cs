using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Game.Components.Views;
using Sources.Game.Constants;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils;
using UnityEngine;
#if UNITY_EDITOR
using Sources.PseudoEditor;
#endif

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(EnableableGameObject))]
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    [RequireComponent(typeof(CollisionsReceiver))]
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