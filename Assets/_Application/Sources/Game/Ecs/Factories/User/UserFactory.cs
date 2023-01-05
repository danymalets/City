using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Pool.Instantiators;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly EcsWorld _world;

        public UserFactory(EcsWorld world)
        {
            _world = world;
        }

        public EcsEntity CreateUser(EcsEntity carEntity)
        {
            EcsEntity user = _world.NewEntity();

            user.Add<UserTag>();
            user.Add<MoveInput>();
            user.Set(new PlayerInCar { Car = carEntity });

            return user;
        }
    }
}