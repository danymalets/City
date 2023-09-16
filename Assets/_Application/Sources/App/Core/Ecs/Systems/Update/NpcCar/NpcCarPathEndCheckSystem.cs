using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
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
                Entity carEntity = npcEntity.Get<PlayerInCar>().CarPlaceData.Car;
                IWheelsSystem carWheels = carEntity.GetRef<IWheelsSystem>();

                if (npcOnPath.PathLine.IsEnded(carWheels.RootPosition))
                {
                    npcEntity.Set(new NpcPointReachedEvent{Point = npcOnPath.PathLine.Target});
                }
            }
        }
    }
}