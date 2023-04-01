using Scellecs.Morpeh;
using Sources.App.Game.GameObjects.RoadSystem;
using Sources.Di;

namespace Sources.App.Game.Ecs.Factories
{
    public interface IPathesFactory : IService
    {
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
    }
}