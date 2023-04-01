using Scellecs.Morpeh;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Despawners
{
    public interface IPlayersDespawner : IService
    {
        void DespawnNpc(Entity playerEntity);
    }
}