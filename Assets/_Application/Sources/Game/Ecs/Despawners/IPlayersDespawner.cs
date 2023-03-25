using Scellecs.Morpeh;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Despawners
{
    public interface IPlayersDespawner : IService
    {
        void DespawnNpc(Entity playerEntity);
    }
}