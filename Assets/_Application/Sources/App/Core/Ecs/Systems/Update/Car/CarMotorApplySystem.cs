using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Car
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