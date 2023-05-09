using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.App.Data.Players
{
    public class PlayerAnimator : IPlayerAnimator
    {
        private readonly IAnimator _animator;
        private readonly int _baseLayer;

        public PlayerAnimator(IAnimator animator)
        {
            _animator = animator;
            _animator.KeepAnimatorControllerStateOnDisable = true;
            _baseLayer = _animator.GetLayerIndex(Layers.BaseLayer);
        }
        public void EnterCar(CarSideType sideType, bool isForce = false)
        {
            _animator.SetBool(
                sideType == CarSideType.Left
                    ? Parameters.InCarLeft
                    : Parameters.InCarRight, true);

            if (isForce)
            {
                _animator.Play(
                    sideType == CarSideType.Left
                        ? Names.InCarLeft
                        : Names.InCarRight, _baseLayer, Random.value);
            }
        }

        public void ExitCar(bool isForce)
        {
            _animator.SetBool(Parameters.InCarLeft, false);
            _animator.SetBool(Parameters.InCarRight, false);

            if (isForce)
            {
                SetMoveSpeed(0, true);
            }
        }

        public void SetMoveSpeed(float speed, bool isForce = false)
        {
            _animator.SetFloat(Parameters.Speed, speed);

            if (isForce)
            {
                _animator.SetFloat(Parameters.Speed, 0);
                _animator.SetBool(Parameters.Die, false);
                _animator.SetBool(Parameters.InCarLeft, false);
                _animator.SetBool(Parameters.InCarRight, false);
                
                _animator.Play(Names.MoveBlendTree, _baseLayer, Random.value);
            }
        }

        public void Die()
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
            public static int InCarLeft = Animator.StringToHash(nameof(InCarLeft));
            public static int InCarRight = Animator.StringToHash(nameof(InCarRight));
        }

        private static class Parameters
        {
            public static int Speed = Animator.StringToHash(nameof(Speed));
            public static int Die = Animator.StringToHash(nameof(Die));
            public static int InCarLeft = Animator.StringToHash(nameof(InCarLeft));
            public static int InCarRight = Animator.StringToHash(nameof(InCarRight));
        }
    }
}