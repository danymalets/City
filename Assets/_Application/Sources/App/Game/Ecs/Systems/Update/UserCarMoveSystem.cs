using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.User;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Libs;

namespace Sources.App.Game.Ecs.Systems.Update
{
    public class UserCarMoveSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserCarInput, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref UserCarInput userCarInput = ref playerEntity.Get<UserCarInput>();
                
                Entity carEntity = playerEntity.Get<PlayerInCar>().Car;

                float signedSpeed = carEntity.GetAccess<IRigidbody>().SignedSpeed;

                carEntity.Set(new ChangeSteeringAngleRequest { AngleCoefficient = userCarInput.Horizontal });

                float motorCoefficient = userCarInput.Vertical;

                BreakType breakType = BreakType.None;
                
                if (userCarInput.Vertical == 1 && DMath.Less(signedSpeed, 0))
                {
                    breakType = BreakType.Max;
                    motorCoefficient = 0;
                }
                else if (userCarInput.Vertical == -1 && DMath.Greater(signedSpeed, 0))
                {
                    breakType = BreakType.Max;
                    motorCoefficient = 0;
                }
                else if (userCarInput.Vertical == 0)
                {
                    breakType = BreakType.Max;
                }
                else
                {
                    breakType = BreakType.None;
                }

                carEntity.Get<CarMotorCoefficient>().Coefficient = motorCoefficient;
                carEntity.Get<CarBreak>().BreakType = breakType;
            }
        }
    }
}