using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerSmoothAngleSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref PlayerTargetAngle playerTargetAngle = ref entity.Get<PlayerTargetAngle>();
                ref PlayerSmoothAngle playerSmoothAngle = ref entity.Get<PlayerSmoothAngle>();
                RotationSpeed rotationSpeed = entity.Get<RotationSpeed>();

                playerSmoothAngle.Value = Mathf.MoveTowardsAngle(
                    playerSmoothAngle.Value, playerTargetAngle.Value, deltaTime * rotationSpeed.Value);
            }
        }
    }
}