using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarMotorApplySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag, CarMotorCoefficient, Mono<ICarData>, Mono<ICarWheels>>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                ICarWheels carWheels = carEntity.GetMono<ICarWheels>();
                ICarData carData = carEntity.GetMono<ICarData>();
                float motorCoefficient = carEntity.Get<CarMotorCoefficient>().Coefficient;
                
                int motorAxesCount = carWheels.AxleInfo.Count(ai => ai.Motor);
            
                float motor = motorCoefficient * carData.MaxMotorTorque / motorAxesCount;
            
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