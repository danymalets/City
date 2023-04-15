using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
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