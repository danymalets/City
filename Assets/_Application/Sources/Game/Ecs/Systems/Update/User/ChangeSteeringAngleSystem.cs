using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game.Ecs.Systems.Update.User
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