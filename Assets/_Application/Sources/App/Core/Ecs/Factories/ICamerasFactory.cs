using Scellecs.Morpeh;
using Sources.Utils.Di;

namespace Sources.App.Core.Ecs.Factories
{
    public interface ICamerasFactory : IService
    {
        Entity CreateCamera();
    }
}