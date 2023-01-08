using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Gizmoses;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Npc
{
    public class NpcCarPathMoveSystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcCarPath>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity npc in _filter)
            {
                ref NpcCarPath npcCarPath = ref npc.Get<NpcCarPath>();
                Entity carEntity = npc.Get<PlayerInCar>().Car;
                ICarWheels carWheels = carEntity.GetMono<ICarWheels>();
                ITransform carTransform = carEntity.GetMono<ITransform>();
                
                carEntity.Get<CarMotorCoefficient>().Coefficient = 0.5f;

                float signedAngle = Vector3.SignedAngle(carTransform.Rotation.GetForward().WithY(0),
                    (npcCarPath.Path.Target.Position - carWheels.RootPosition).WithY(0), Vector3.up);

                // Debug.Log($"angle = {signedAngle}");
                
                carEntity.Get<SteeringAngle>().Value = signedAngle;
            }
        }
    }
}