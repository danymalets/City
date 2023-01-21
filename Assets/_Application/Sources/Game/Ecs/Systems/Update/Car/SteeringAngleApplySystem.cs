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
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class SteeringAngleApplySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<SmoothSteeringAngle, Mono<ICarData>, Mono<ICarWheels>>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                ICarWheels carWheels = carEntity.GetMono<ICarWheels>();
                float steeringAngle = carEntity.Get<SmoothSteeringAngle>().Value;

                AxleInfo axleInfo = carWheels.AxleInfo[0];

                axleInfo.LeftWheelCollider.steerAngle = steeringAngle;
                axleInfo.RightWheelCollider.steerAngle = steeringAngle;
            }
        }
    }
}