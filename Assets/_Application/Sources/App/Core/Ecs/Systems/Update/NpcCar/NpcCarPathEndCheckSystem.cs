using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcCarPathEndCheckSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                IWheelsSystem carWheels = carEntity.GetAccess<IWheelsSystem>();

                if (npcOnPath.PathLine.IsEnded(carWheels.RootPosition))
                {
                    npcEntity.Set(new NpcPointReachedEvent{Point = npcOnPath.PathLine.Target});
                }
            }
        }
    }
}