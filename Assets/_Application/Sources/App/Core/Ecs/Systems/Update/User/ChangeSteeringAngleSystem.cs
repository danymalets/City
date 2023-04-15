using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.ProjectServices.BalanceServices;
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

        protected override void OnConstruct()
        {
            _filter = _world.Filter<CarTag, ChangeSteeringAngleRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                float maxSteeringAngle = _carsBalance.MaxSteeringAngle;
                float angleCoefficient = carEntity.Get<ChangeSteeringAngleRequest>().AngleCoefficient;

                carEntity.Get<SteeringAngle>().Value = angleCoefficient * maxSteeringAngle;
            }
        }
    }
}