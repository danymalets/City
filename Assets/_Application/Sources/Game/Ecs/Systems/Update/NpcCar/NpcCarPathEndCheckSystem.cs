using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarPathEndCheckSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                ICarWheels carWheels = carEntity.GetMono<ICarWheels>();

                if (npcOnPath.PathLine.IsEnded(carWheels.RootPosition))
                {
                    npcEntity.Set(new NpcCarPointReachedEvent{Point = npcOnPath.PathLine.Target});
                }
            }
        }
    }
}