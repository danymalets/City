using Scellecs.Morpeh;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Ecs.Systems.Update.Car
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