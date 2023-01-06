using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Factories
{
    public class UserFactory : EcsFactory, IUserFactory
    {
        public UserFactory(World world) : base(world)
        {
        }

        public Entity CreateUser(Entity carEntity)
        {
            return _world.CreateWithEmptyMono()
                .Add<UserTag>()
                .Add<MoveInput>()
                .Set(new PlayerInCar { Car = carEntity });
        }
    }
}