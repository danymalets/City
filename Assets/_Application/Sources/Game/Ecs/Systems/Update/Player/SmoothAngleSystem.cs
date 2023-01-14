using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class SmoothAngleSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<TargetAngle, SmoothAngle>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref TargetAngle targetAngle = ref entity.Get<TargetAngle>();
                ref SmoothAngle smoothAngle = ref entity.Get<SmoothAngle>();
                ref RotationSpeed rotationSpeed = ref entity.Get<RotationSpeed>();

                smoothAngle.Value = Mathf.MoveTowardsAngle(
                    smoothAngle.Value, targetAngle.Value, deltaTime * rotationSpeed.Value);
            }
        }
    }
}