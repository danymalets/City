using _Application.Sources.App.Data.Pathes;
using _Application.Sources.Utils.Di;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Factories
{
    public interface IPathesFactory : IService
    {
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
    }
}