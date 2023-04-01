using Scellecs.Morpeh;
using Sources.App.Game.Components.Monos;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarPathSteeringAngleSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity npc in _filter)
            {
                ref NpcOnPath npcOnPath = ref npc.Get<NpcOnPath>();
                Entity carEntity = npc.Get<PlayerInCar>().Car;
                IWheelsSystem carWheels = carEntity.GetAccess<IWheelsSystem>();
                ITransform carTransform = carEntity.GetAccess<ITransform>();
                
                float signedAngle = Vector3.SignedAngle(carTransform.Rotation.GetForward().WithY(0),
                    (npcOnPath.PathLine.Target.Position - carWheels.RootPosition).WithY(0), Vector3.up);

                // Debug.Log($"angle = {signedAngle}");
                
                carEntity.Get<SteeringAngle>().Value = signedAngle;
            }
        }
    }
}