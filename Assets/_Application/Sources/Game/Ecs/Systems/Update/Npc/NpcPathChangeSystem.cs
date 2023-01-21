using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Npc
{
    public class NpcPathChangeSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity npc in _filter)
            {
                ref NpcOnPath npcOnPath = ref npc.Get<NpcOnPath>();
                Vector3 position = npc.GetMono<ITransform>().Position;

                if (npcOnPath.PathLine.IsEnded(position))
                {
                    npcOnPath.PathLine = npcOnPath.PathLine.Target.Targets.GetRandom().FirstPathLine;
                }
            }
        }
    }
}