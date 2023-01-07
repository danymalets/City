using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities;

namespace Sources.Game.Ecs.Systems.Update
{
    public class PlayerCarMoveSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<MoveInput, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref MoveInput moveInput = ref playerEntity.Get<MoveInput>();
                
                ICarEngine carEngine = playerEntity.Get<PlayerInCar>().Car.GetMono<ICarEngine>();
                
                carEngine.SetAngleCoefficient(moveInput.Horizontal);
                carEngine.SetMotorCoefficient(moveInput.Vertical);

                if (moveInput.Vertical == 1 && DMath.Less(carEngine.Speed, 0))
                {
                    carEngine.SetMaxBreak();
                    carEngine.SetMotorCoefficient(0);
                }
                else if (moveInput.Vertical == -1 && DMath.Greater(carEngine.Speed, 0))
                {
                    carEngine.SetMaxBreak();
                    carEngine.SetMotorCoefficient(0);
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