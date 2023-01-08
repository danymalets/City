using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class WheelGeometrySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<Mono<ICarWheels>>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                ICarWheels carWheels = carEntity.GetMono<ICarWheels>();

                foreach (AxleInfo axleInfo in carWheels.AxleInfo)
                {
                    ApplyGeometry(axleInfo.LeftWheelCollider, axleInfo.LeftWheelGeometry);
                    ApplyGeometry(axleInfo.RightWheelCollider, axleInfo.RightWheelGeometry);
                }
            }
        }

        private void ApplyGeometry(WheelCollider wheelCollider, Transform geometry)
        {
            wheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);

            geometry.position = position;
            geometry.rotation = rotation;
        }
    }
}