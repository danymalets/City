using Scellecs.Morpeh;
using Sources.App.Data.Pathes;
using Sources.Utils.Di;

namespace Sources.App.Core.Ecs.Factories
{
    public interface IPathesFactory : IService
    {
        Entity CreatePathes<TTag, TRelatedAreaTag>(IPathSystem pathSystem)
            where TTag : struct, IComponent
            where TRelatedAreaTag : struct, IComponent;
    }
}