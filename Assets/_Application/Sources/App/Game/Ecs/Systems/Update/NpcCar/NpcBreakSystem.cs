using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcBreakSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcBreakRequest>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref PlayerTargetSpeed playerTargetSpeed = ref npcEntity.Get<PlayerTargetSpeed>();

                playerTargetSpeed.Value = 0;
            }
        }
    }
}