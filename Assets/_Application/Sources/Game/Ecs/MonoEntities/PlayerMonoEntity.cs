using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Game.Components.Views;
using Sources.Game.Constants;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils;
using Sources.PseudoEditor;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.MonoEntities
{
    [RequireComponent(typeof(EnableableGameObject))]
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public class PlayerMonoEntity : MonoEntity
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

        [SerializeField]
        private SafeColliderBase[] _colliders;

        public IEnableableGameObject EnableableGameObject => _enableableGameObject;
        public IRigidbodySwitcher RigidbodySwitcher => _rigidbodySwitcher;
        public ITransform Transform => _transform;
        public IPlayerBorders PlayerBorders => _playerBorders;
        public IEnumerable<IEntityAccess> Colliders => _colliders;
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
            _colliders = GetComponentsInChildren<SafeColliderBase>();

            PhysicMaterial physicsMaterial = DEditor.EditorServices.Assets.PhysicsAssets.PlayerPhysicsMaterial;

            foreach (SafeColliderBase collider in _colliders)
            {
                collider.Layer = Layers.Player;
                collider.PhysicsMaterial = physicsMaterial;
            }
        }
#endif
    }
}