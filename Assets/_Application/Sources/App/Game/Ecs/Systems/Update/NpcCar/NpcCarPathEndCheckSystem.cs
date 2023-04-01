using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Components.Monos;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
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