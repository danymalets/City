using Scellecs.Morpeh;
using Sources.Services.Di;

namespace Sources.App.Game.Ecs.Factories
{
    public interface ICamerasFactory : IService
    {
        Entity CreateCamera();
    }
}