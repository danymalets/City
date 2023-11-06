using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CarsBalances;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class CarMotorApplySystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public CarMotorApplySystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>().Build();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IWheelsSystem carWheels = carEntity.GetRef<IWheelsSystem>();
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