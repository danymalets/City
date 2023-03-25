using Scellecs.Morpeh;
using Sources.Game.Components.Old.CarCollider;
using Sources.Game.Components.Views;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Npc
{
    public class NpcForwardColliderSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcForwardColliderSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>()
                .SimulationBalance;
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