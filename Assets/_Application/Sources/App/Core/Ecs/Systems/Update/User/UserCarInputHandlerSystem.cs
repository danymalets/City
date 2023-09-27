using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.User;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserCarInputHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag, PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref UserCarInput userCarInput = ref playerEntity.Get<UserCarInput>();
                
                Entity carEntity = playerEntity.Get<PlayerInCar>().CarPlaceData.Car;
                
                float signedSpeed = carEntity.GetRef<IRigidbody>().SignedSpeed;
                
                ref CarSteeringAngleCoefficient carSteeringAngleCoefficient = 
                    ref playerEntity.Get<CarSteeringAngleCoefficient>();
                
                carSteeringAngleCoefficient.AngleCoefficient = userCarInput.Horizontal;

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