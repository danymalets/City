using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Npc
{
    public class NpcPathEndCheckSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                Vector3 position = npcEntity.GetAccess<ITransform>().Position;

                if (npcOnPath.PathLine.IsEnded(position))
                {
                    npcEntity.Set(new NpcPointReachedEvent{Point = npcOnPath.PathLine.Target});
                    //npcOnPath.PathLine = npcOnPath.PathLine.Target.Targets.GetRandom().FirstPathLine;
                }
            }
        }
    }
}