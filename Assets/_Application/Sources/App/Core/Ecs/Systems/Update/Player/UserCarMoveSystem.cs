using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
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