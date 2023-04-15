using _Application.Sources.App.Core.Ecs.Components.Npc;
using _Application.Sources.App.Core.Ecs.Components.Npc.NpcCar;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Npc
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