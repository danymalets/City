using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarBorder;
using Sources.Game.Ecs.Components.Views.Transform;
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

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref ForwardTrigger forwardTrigger = ref npcEntity.Get<ForwardTrigger>();
                ref SmoothAngle angle = ref npcEntity.Get<SmoothAngle>();
                ITransform transform = npcEntity.GetMono<ITransform>();
                IEntityBorders borders = npcEntity.GetMono<IEntityBorders>();
                
                Quaternion triggerRotation = transform.Rotation.WithEulerY(angle.Value);

                Vector3 triggerCenter = transform.Position + triggerRotation * Vector3.forward * 
                    (borders.HalfExtents.z + _simulationBalance.NpcTriggerLength / 2);

                forwardTrigger.Center = triggerCenter;
                forwardTrigger.Rotation = triggerRotation;
                forwardTrigger.Size = new Vector3(
                    borders.HalfExtents.x * 2, borders.HalfExtents.y * 2, _simulationBalance.NpcTriggerLength);
                
                _updateGizmosContext.DrawCube(
                    forwardTrigger.Center, forwardTrigger.Rotation, forwardTrigger.Size, Color.red);
            }
        }
    }
}