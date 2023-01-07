using Scellecs.Morpeh;
using Sources.Game.Characters;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Factories.Npc
{
    public class NpcFactory : EcsFactory, INpcFactory
    {
        public NpcFactory(World world) : base(world)
        {
        }

        public Entity Create(Entity carEntity)
        {
            return _world.CreateWithEmptyMono()
                .Add<PlayerTag>()
                .Add<NpcTag>()
                .Add<MoveInput>()
                .Set(new PlayerInCar { Car = carEntity });
        }
    }
}