using Scellecs.Morpeh;
using Sources.Data.Pathes;
using Sources.Services.Di;

namespace Sources.App.Game.Ecs.Factories
{
    public interface IPathesFactory : IService
    {
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
    }
}