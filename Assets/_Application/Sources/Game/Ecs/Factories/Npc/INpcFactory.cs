using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories.Npc
{
    public interface INpcFactory : IService
    {
        Entity Create(Entity carEntity, Path path);
    }
}