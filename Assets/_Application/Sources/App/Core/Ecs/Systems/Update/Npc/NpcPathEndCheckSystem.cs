using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class NpcPathEndCheckSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                Vector3 position = npcEntity.GetRef<ITransform>().Position;

                if (npcOnPath.PathLine.IsEnded(position))
                {
                    npcEntity.Set(new NpcPointReachedEvent{Point = npcOnPath.PathLine.Target});
                    //npcOnPath.PathLine = npcOnPath.PathLine.Target.Targets.GetRandom().FirstPathLine;
                }
            }
        }
    }
}