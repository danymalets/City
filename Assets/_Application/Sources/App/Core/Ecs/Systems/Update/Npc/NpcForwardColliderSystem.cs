using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Players;
using _Application.Sources.Utils.CommonUtils.Data;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class NpcForwardColliderSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcForwardColliderSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
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