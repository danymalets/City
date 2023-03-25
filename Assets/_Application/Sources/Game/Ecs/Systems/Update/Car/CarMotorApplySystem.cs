using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.Cars;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarMotorApplySystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public CarMotorApplySystem()
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
                IWheelsSystem carWheels = carEntity.GetAccess<IWheelsSystem>();
                float motorCoefficient = carEntity.Get<CarMotorCoefficient>().Coefficient;
                
                int motorAxesCount = carWheels.AxleInfo.Count(ai => ai.Motor);
            
                float motor = motorCoefficient * _carsBalance.MaxMotorTorque / motorAxesCount;
            
                foreach (AxleInfo axleInfo in carWheels.AxleInfo)
                {
                    if (axleInfo.Motor)
                    {
                        axleInfo.LeftWheelCollider.motorTorque = motor;
                        axleInfo.RightWheelCollider.motorTorque = motor;
                    }
                }
            }
        }
    }
}