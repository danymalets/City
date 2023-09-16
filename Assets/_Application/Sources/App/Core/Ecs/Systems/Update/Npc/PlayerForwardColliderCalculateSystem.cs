using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Players;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Data;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class PlayerForwardColliderCalculateSystem : DUpdateSystem
    {
        private Filter _npcOnPathfilter;
        private readonly SimulationBalance _simulationBalance;

        public PlayerForwardColliderCalculateSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _npcOnPathfilter = _world.Filter<NpcTag, CheckForwardTriggerRequest>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _npcOnPathfilter)
            {
                ref CheckForwardTriggerRequest checkForwardTriggerRequest = 
                    ref npcEntity.Get<CheckForwardTriggerRequest>();
                
                ref PlayerMoveAngle angle = ref npcEntity.Get<PlayerMoveAngle>();
                ITransform transform = npcEntity.GetRef<ITransform>();
                CapsuleData borders = npcEntity.GetRef<IPlayerBorders>().SafeCapsuleCollider.CapsuleData;

                Quaternion triggerRotation = transform.Rotation.WithEulerY(angle.Value);

                Vector3 triggerCenter = transform.Position + triggerRotation * (Vector3.forward * 
                    (borders.Radius + _simulationBalance.NpcTriggerLength / 2)) + 
                                        triggerRotation * Vector3.up * borders.Height / 2;

                checkForwardTriggerRequest.Center = triggerCenter;
                checkForwardTriggerRequest.Rotation = triggerRotation;
                checkForwardTriggerRequest.Size = new Vector3(borders.Radius * 2, borders.Height, 
                    _simulationBalance.NpcTriggerLength);
            }
        }
    }
}