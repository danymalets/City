using Scellecs.Morpeh;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public interface IUserFactory : IService
    {
        Entity CreateUser(Entity carEntity);
    }
}