using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class SteeringAngleApplySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                IWheelsSystem carWheels = carEntity.GetAccess<IWheelsSystem>();
                float steeringAngle = carEntity.Get<SmoothSteeringAngle>().Value;

                AxleInfo axleInfo = carWheels.AxleInfo[0];

                axleInfo.LeftWheelCollider.steerAngle = steeringAngle;
                axleInfo.RightWheelCollider.steerAngle = steeringAngle;
            }
        }
    }
}