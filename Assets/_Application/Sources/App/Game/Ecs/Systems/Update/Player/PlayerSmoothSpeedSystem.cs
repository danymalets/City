using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Player
{
    public class PlayerSmoothSpeedSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                PlayerTargetSpeed targetSpeed = npcEntity.Get<PlayerTargetSpeed>();
                ref PlayerSmoothSpeed smoothSpeed = ref npcEntity.Get<PlayerSmoothSpeed>();

                smoothSpeed.Value = Mathf.MoveTowards(smoothSpeed.Value, targetSpeed.Value, deltaTime * 6);
            }
        }
    }
}