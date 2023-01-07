using Scellecs.Morpeh;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories.Npc
{
    public interface INpcFactory : IService
    {
        Entity Create(Entity carEntity);
    }
}