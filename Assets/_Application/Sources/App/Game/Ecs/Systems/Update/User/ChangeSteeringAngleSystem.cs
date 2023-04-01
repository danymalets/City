using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;

namespace Sources.App.Game.Ecs.Systems.Update.User
{
    public class ChangeSteeringAngleSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public ChangeSteeringAngleSystem()
        {
            _carsBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CarsBalance;
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