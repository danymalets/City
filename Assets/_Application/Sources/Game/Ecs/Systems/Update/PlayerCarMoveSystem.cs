using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update
{
    public class PlayerCarMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveInput, PlayerInCar> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref MoveInput moveInput = ref _filter.Get1(i);
                ref PlayerInCar playerInCar = ref _filter.Get2(i);
                
                ICarEngine carEngine = playerInCar.Car.Get<ViewComponent<ICarEngine>>().View;
                
                carEngine.SetAngleCoefficient(moveInput.Horizontal);
                carEngine.SetMotorCoefficient(moveInput.Vertical);

                if (moveInput.Vertical == 1 && DMath.Less(carEngine.Speed, 0))
                {
                    carEngine.SetMaxBreak();
                    //carEngine.SetMotorCoefficient(0);
                }
                else if (moveInput.Vertical == -1 && DMath.Greater(carEngine.Speed, 0))
                {
                    carEngine.SetMaxBreak();
                    //carEngine.SetMotorCoefficient(0);
                }
                else if (moveInput.Vertical == 0)
                {
                    carEngine.SetLiteBreak();
                }
                else
                {
                    carEngine.ResetBreak();
                }
            }
        }
    }
}