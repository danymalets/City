using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.PlayerAnimators
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField]
        private Animator _animator;

        public void SetIdle()
        {
            _animator.SetBool(Parameters.Move, false);
        }

        public void SetMove()
        {
            _animator.SetBool(Parameters.Move, true);
        }

        private static class Parameters
        {
            public static int Move = Animator.StringToHash(nameof(Move));
        }
    }
}