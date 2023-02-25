using System;
using Sources.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Game.Ecs.Components.Views.PlayerAnimators
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField]
        private Animator _animator;

        private int _baseLayer;

        private void Awake()
        {
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