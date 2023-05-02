using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class ChangeSteeringAngleSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public ChangeSteeringAngleSystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                float maxSteeringAngle = _carsBalance.MaxSteeringAngle;
                float angleCoefficient = playerEntity.Get<CarSteeringAngleCoefficient>().AngleCoefficient;
                Entity carEntity = playerEntity.Get<PlayerInCar>().CarPlaceData.Car;
                
                carEntity.Get<SteeringAngle>().Value = angleCoefficient * maxSteeringAngle;
            }
        }
    }
}