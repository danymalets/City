using System;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class WheelGeometrySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag, Ref<IRigidbody>>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IWheelsSystem carWheels = carEntity.GetRef<IWheelsSystem>();

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