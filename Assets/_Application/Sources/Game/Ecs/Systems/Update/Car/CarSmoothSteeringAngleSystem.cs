using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class CarSmoothSteeringAngleSystem : DFixedUpdateSystem
    {
        public const float AngleSpeed = 180f;
        
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<SteeringAngle, SmoothSteeringAngle>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref SmoothSteeringAngle smoothAngle = ref entity.Get<SmoothSteeringAngle>();
                float angle = entity.Get<SteeringAngle>().Value;
                
                smoothAngle.Value = Mathf.MoveTowards(smoothAngle.Value, angle,
                    AngleSpeed * fixedDeltaTime);
            }
        }
    }
}