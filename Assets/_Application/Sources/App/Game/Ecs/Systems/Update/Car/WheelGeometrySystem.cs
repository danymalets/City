using _Application.Sources.MonoViews;
using _Application.Sources.MonoViews.MonoViews;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Car
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