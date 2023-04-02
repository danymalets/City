using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data.MonoViews;
using Sources.Data.MonoViews.MonoViews;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Update.Car
{
    public class CarMotorApplySystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly CarsBalance _carsBalance;

        public CarMotorApplySystem()
        {
            _carsBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CarsBalance;
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