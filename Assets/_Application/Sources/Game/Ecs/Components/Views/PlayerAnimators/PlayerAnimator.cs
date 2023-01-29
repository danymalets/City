using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.PlayerAnimators
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField]
        private Animator _animator;

        public void SetMoveSpeed(float speed)
        {
            _animator.SetFloat(Parameters.Speed, speed);
        }

        public void SetDie()
        {
            _animator.SetBool(Parameters.Die, false);
        }

        private static class Parameters
        {
            public static int Speed = Animator.StringToHash(nameof(Speed));
            public static int Die = Animator.StringToHash(nameof(Die));
        }
    }
}