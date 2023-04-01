using _Application.Sources.MonoViews.MonoViews;
using _Application.Sources.Utils.Data;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Di;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Npc
{
    public class NpcForwardColliderSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcForwardColliderSystem()
        {
            _simulationBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().SimulationBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref ForwardTrigger forwardTrigger = ref npcEntity.Get<ForwardTrigger>();
                ref PlayerSmoothAngle angle = ref npcEntity.Get<PlayerSmoothAngle>();
                ITransform transform = npcEntity.GetAccess<ITransform>();
                CapsuleData borders = npcEntity.GetAccess<IPlayerBorders>().SafeCapsuleCollider.CapsuleData;

                Quaternion triggerRotation = transform.Rotation.WithEulerY(angle.Value);

                Vector3 triggerCenter = transform.Position + triggerRotation * (Vector3.forward * 
                    (borders.Radius + _simulationBalance.NpcTriggerLength / 2));

                forwardTrigger.Center = triggerCenter;
                forwardTrigger.Rotation = triggerRotation;
                forwardTrigger.Size = new Vector3(
                    borders.Radius * 2, borders.Radius, _simulationBalance.NpcTriggerLength);
                
                _updateGizmosContext.DrawCube(
                    forwardTrigger.Center, forwardTrigger.Rotation, forwardTrigger.Size, Color.red);
            }
        }
    }
}