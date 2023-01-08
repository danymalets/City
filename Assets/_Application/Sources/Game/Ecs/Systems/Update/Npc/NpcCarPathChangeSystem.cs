using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Npc
{
    public class NpcCarPathChangeSystem : DFixedUpdateSystem
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

                if (npcCarPath.Path.IsEnded(carWheels.RootPosition))
                     npcCarPath.Path = npcCarPath.Path.Target.GetRandomTargetPath();
            }
        }
    }
}