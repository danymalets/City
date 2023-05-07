using Sirenix.OdinInspector;
using Sources.App.Data.Constants;
using Sources.App.Services.AssetsServices.Monos.Players;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using UnityEngine.AI;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities
{
    public partial class PlayerMonoEntity
    {
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
            _navMeshAgent = GetComponentInChildren<NavMeshObstacle>();

            _playerBorders.SafeCapsuleCollider.Layer = Layers.Player;
        }
#endif
    }
}