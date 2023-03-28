using Scellecs.Morpeh;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class WheelGeometrySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IWheelsSystem carWheels = carEntity.GetAccess<IWheelsSystem>();

                foreach (AxleInfo axleInfo in carWheels.AxleInfo)
                {
                    ApplyGeometry(axleInfo.LeftWheelCollider, axleInfo.LeftWheelGeometry);
                    ApplyGeometry(axleInfo.RightWheelCollider, axleInfo.RightWheelGeometry, true);
                }
            }
        }

        private void ApplyGeometry(WheelCollider wheelCollider, Transform geometry, bool isReverse = false)
        {
            wheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);

            geometry.position = position;
            geometry.rotation = rotation;
            
            geometry.localScale = geometry.localScale.WithX(isReverse ? -1 : 1);
        }
    }
}