using System.Collections;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;
using UnityEngine;

namespace Sources.Game.Characters.StateTree.InCar
{
    public class MoveBackState : LeafState<Car>
    {
        private const float Duration = 5f;

        public MoveBackState(NodeStateBase parent) : base(parent)
        {
        }

        public override void OnEnter(Car car)
        {
            _coroutineContext.StartCoroutine(MoveCoroutine(car));
        }

        public IEnumerator MoveCoroutine(Car car)
        {
            float elapsedTime = Duration;
            while (elapsedTime > 0)
            {
                yield return null;
                elapsedTime -= Time.deltaTime;

                if (car.HasCarInBack())
                {
                    car.SetMotorCoefficient(0f);
                }
                else
                {
                    car.SetMotorCoefficient(-0.2f);
                }
            }
        }

        protected override void OnExit()
        {
        }
    }
}