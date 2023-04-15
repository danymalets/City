using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Car
{
    public class SteeringAngleApplySystem : DUpdateSystem
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
                float steeringAngle = carEntity.Get<SmoothSteeringAngle>().Value;

                AxleInfo axleInfo = carWheels.AxleInfo[0];

                axleInfo.LeftWheelCollider.steerAngle = steeringAngle;
                axleInfo.RightWheelCollider.steerAngle = steeringAngle;
            }
        }
    }
}