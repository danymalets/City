using System.Linq;
using Sirenix.OdinInspector;
using Sources.App.Data.Constants;
using Sources.App.Services.AssetsServices.Monos.Players;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Player
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

            gameObject.SetLayerRecursive(Layers.Player);

            _rootTransform = GetComponentsInChildren<Transform>()
                .First(t => t.gameObject.name == "Root")
                .gameObject.AddComponent<SafeTransform>();
        }
#endif
    }
}