using Scellecs.Morpeh;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public interface ICamerasFactory : IService
    {
        Entity CreateCamera();
    }
}