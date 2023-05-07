using Sirenix.OdinInspector;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Players;
using Sources.App.Services.AssetsServices.Monos.Players;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities
{
    [RequireComponent(typeof(EnableableGameObject))]
    [RequireComponent(typeof(SafeTransform))]
    [RequireComponent(typeof(RigidbodySwitcher))]
    public partial class PlayerMonoEntity : MonoEntity, IPlayerMonoEntity
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
        private NavMeshObstacle _navMeshAgent;

        public IEnableableGameObject EnableableGameObject => _enableableGameObject;
        public IRigidbodySwitcher RigidbodySwitcher => _rigidbodySwitcher;
        public ITransform Transform => _transform;
        public IPlayerBorders PlayerBorders => _playerBorders;
        public IAnimator Animator => _animator;
        public NavMeshObstacle NavMeshObstacle => _navMeshAgent;
    }
}