using Scellecs.Morpeh;
using Sources.Game.Characters;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Factories.Npc
{
    public class NpcFactory : EcsFactory, INpcFactory
    {
        public NpcFactory(World world) : base(world)
        {
        }

        public Entity Create(Entity carEntity, Path path)
        {
            return _world.CreateEntity()
                .Add<NpcTag>()
                .Add<PlayerTag>()
                .Set(new PlayerInCar { Car = carEntity })
                .Set(new NpcCarPath { Path = path });
        }
    }
}