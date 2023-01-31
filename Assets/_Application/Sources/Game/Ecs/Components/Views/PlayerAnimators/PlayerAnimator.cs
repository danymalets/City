using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.PlayerAnimators
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField]
        private Animator _animator;

        public void Setup()
        {
            _animator.SetFloat(Parameters.Speed, 0);
            _animator.SetBool(Parameters.Die, false);
            
            _animator.Play(Names.MoveBlendTree, -1, Random.value);
        }
        
        public void SetMoveSpeed(float speed)
        {
            _animator.SetFloat(Parameters.Speed, speed);
        }

        public void SetDie()
        {
            _animator.SetBool(Parameters.Die, true);
        }

        private static class Parameters
        {
            public static int Speed = Animator.StringToHash(nameof(Speed));
            public static int Die = Animator.StringToHash(nameof(Die));
        }
        
        private static class Names
        {
            public static int MoveBlendTree = Animator.StringToHash(nameof(MoveBlendTree));
        }
    }
}