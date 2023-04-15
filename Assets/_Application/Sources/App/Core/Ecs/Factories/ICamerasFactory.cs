using _Application.Sources.Utils.Di;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Factories
{
    public interface ICamerasFactory : IService
    {
        Entity CreateCamera();
    }
}