using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Views.Data;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarSmoothSteeringAngleSystem : DUpdateSystem
    {
        public const float AngleSpeed = 180f;
        
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<SteeringAngle, SmoothSteeringAngle>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity carEntity in _filter)
            {
                ref SmoothSteeringAngle smoothAngle = ref carEntity.Get<SmoothSteeringAngle>();
                float angle = carEntity.Get<SteeringAngle>().Value;
                float maxSteeringAngle = carEntity.GetMono<ICarData>().MaxSteeringAngle;

                smoothAngle.Value = Mathf.MoveTowards(smoothAngle.Value, angle,
                    AngleSpeed * fixedDeltaTime);
                
                smoothAngle.Value = Mathf.Clamp(smoothAngle.Value, -maxSteeringAngle, maxSteeringAngle);
            }
        }
    }
}