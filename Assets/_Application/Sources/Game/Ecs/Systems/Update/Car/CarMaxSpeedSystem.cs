using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarMaxSpeedSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public CarMaxSpeedSystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IRigidbody physicBody = carEntity.GetAccess<IRigidbody>();
                float carMaxSpeed = _carsBalance.MaxSpeed;
                float playerMaxSpeed = carEntity.Get<CarMaxSpeed>().Value;
                ref CarMotorCoefficient motorCoefficient = ref carEntity.Get<CarMotorCoefficient>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();

                float maxSpeed = Mathf.Min(carMaxSpeed, playerMaxSpeed);

                if (physicBody.SignedSpeed < 0)
                    maxSpeed /= 2;
                
                if (physicBody.Velocity.magnitude > maxSpeed)
                {
                    motorCoefficient.Coefficient = 0;
                }

                if (physicBody.Velocity.magnitude > maxSpeed + 0.5f)
                {
                    carBreak.BreakType = BreakType.Max;
                }
            }
        }
    }
}