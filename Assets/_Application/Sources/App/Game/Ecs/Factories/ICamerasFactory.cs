using Scellecs.Morpeh;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Factories
{
    public interface ICamerasFactory : IService
    {
        Entity CreateCamera();
    }
}