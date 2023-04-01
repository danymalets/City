using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Npc
{
    public class NpcPathRotateSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npc in _filter)
            {
                ref NpcOnPath npcOnPath = ref npc.Get<NpcOnPath>();
                ITransform transform = npc.GetAccess<ITransform>();

                float targetAngle =
                    Quaternion.LookRotation(npcOnPath.PathLine.Target.Position - transform.Position,
                        Vector3.up).eulerAngles.y;
                
                npc.Get<PlayerTargetAngle>().Value = targetAngle;
            }
        }
    }
}