using _Application.Sources.App.Core.Ecs.Components.Npc;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerSmoothAngleSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
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