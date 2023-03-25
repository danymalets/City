using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public interface IPathesFactory : IService
    {
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
    }
}