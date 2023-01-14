using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarPathSteeringAngleSystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity npc in _filter)
            {
                ref NpcOnPath npcOnPath = ref npc.Get<NpcOnPath>();
                Entity carEntity = npc.Get<PlayerInCar>().Car;
                ICarWheels carWheels = carEntity.GetMono<ICarWheels>();
                ITransform carTransform = carEntity.GetMono<ITransform>();
                
                float signedAngle = Vector3.SignedAngle(carTransform.Rotation.GetForward().WithY(0),
                    (npcOnPath.Path.Target.Position - carWheels.RootPosition).WithY(0), Vector3.up);

                // Debug.Log($"angle = {signedAngle}");
                
                carEntity.Get<SteeringAngle>().Value = signedAngle;
            }
        }
    }
}