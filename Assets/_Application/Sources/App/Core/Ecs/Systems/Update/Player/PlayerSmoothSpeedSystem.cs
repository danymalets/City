using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
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