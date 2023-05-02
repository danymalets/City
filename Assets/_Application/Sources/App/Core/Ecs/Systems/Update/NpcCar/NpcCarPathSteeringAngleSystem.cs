using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcCarPathSteeringAngleSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }

        protected override void OnUpdate(float fixedDeltaTime)
        {
            foreach (Entity npc in _filter)
            {
                ref NpcOnPath npcOnPath = ref npc.Get<NpcOnPath>();
                Entity carEntity = npc.Get<PlayerInCar>().CarPlaceData.Car;
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