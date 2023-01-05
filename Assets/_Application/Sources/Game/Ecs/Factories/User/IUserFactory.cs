using Leopotam.Ecs;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public interface IUserFactory : IService
    {
        EcsEntity CreateUser(EcsEntity carEntity);
    }
}