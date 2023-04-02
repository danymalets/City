using Sources.Utils.DMorpeh.DefaultComponents.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Monos.Components.Old.PlayerAnimators
{
    public class PlayerAnimator :  IPlayerAnimator
    {
        private readonly IAnimator _animator;
        private readonly int _baseLayer;

        public PlayerAnimator(IAnimator animator)
        {
            _animator = animator;
            _baseLayer = _animator.GetLayerIndex(Layers.BaseLayer);
        }
        
        public void Setup()
        {
            _animator.SetFloat(Parameters.Speed, 0);
            _animator.SetBool(Parameters.Die, false);
            
            _animator.Play(Names.MoveBlendTree, _baseLayer, Random.value);
        }
        
        public void SetMoveSpeed(float speed)
        {
            _animator.SetFloat(Parameters.Speed, speed);
        }

        public void SetDie()
        {
            _animator.SetBool(Parameters.Die, true);
        }
        
        private static class Layers
        {
            public static string BaseLayer = nameof(BaseLayer);
        }
        
        private static class Names
        {
            public static int MoveBlendTree = Animator.StringToHash(nameof(MoveBlendTree));
            public static int Falling = Animator.StringToHash(nameof(Falling));
        }

        private static class Parameters
        {
            public static int Speed = Animator.StringToHash(nameof(Speed));
            public static int Die = Animator.StringToHash(nameof(Die));
        }
    }
}