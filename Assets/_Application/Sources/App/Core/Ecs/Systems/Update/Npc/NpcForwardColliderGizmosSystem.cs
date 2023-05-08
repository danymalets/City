using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class NpcForwardColliderGizmosSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CheckForwardTriggerRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref CheckForwardTriggerRequest checkForwardTriggerRequest = ref npcEntity.Get<CheckForwardTriggerRequest>();
                
                _updateGizmosContext.DrawCube(
                    checkForwardTriggerRequest.Center, checkForwardTriggerRequest.Rotation, checkForwardTriggerRequest.Size, Color.red);
            }
        }
    }
}