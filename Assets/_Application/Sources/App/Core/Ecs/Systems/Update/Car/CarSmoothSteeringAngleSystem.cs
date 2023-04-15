using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Car
{
    public class CarSmoothSteeringAngleSystem : DUpdateSystem
    {
        public const float AngleSpeed = 180f;
        
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public CarSmoothSteeringAngleSystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<SteeringAngle, SmoothSteeringAngle>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                ref SmoothSteeringAngle smoothAngle = ref carEntity.Get<SmoothSteeringAngle>();
                float angle = carEntity.Get<SteeringAngle>().Value;
                float maxSteeringAngle = _carsBalance.MaxSteeringAngle;

                smoothAngle.Value = Mathf.MoveTowards(smoothAngle.Value, angle,
                    AngleSpeed * fixedDeltaTime);
                
                smoothAngle.Value = Mathf.Clamp(smoothAngle.Value, -maxSteeringAngle, maxSteeringAngle);
            }
        }
    }
}