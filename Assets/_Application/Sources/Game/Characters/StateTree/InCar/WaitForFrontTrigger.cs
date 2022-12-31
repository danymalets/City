using System.Collections;
using Sources.Game.Characters.StateTree.InCar.DriveToPoint;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;
using UnityEngine;

namespace Sources.Game.Characters.StateTree.InCar
{
    public class WaitForFrontTrigger : LeafState<Car>
    {
        public WaitForFrontTrigger(NodeStateBase parent) : base(parent)
        {
        }

        private const float Duration = 5f;

        public override void OnEnter(Car car)
        {
            _coroutineContext.StartCoroutine(WaitCoroutine(car));
        }

        public IEnumerator WaitCoroutine(Car car)
        {
            float elapsedTime = Duration;
            while (elapsedTime > 0)
            {
                yield return null;
                elapsedTime -= Time.deltaTime;

                if (!car.HasCarInFront())
                {
                    _parent.Enter<DriveByPathNodeState, Car>(car);
                }
            }
        }

        protected override void OnExit()
        {
        }
    }
}