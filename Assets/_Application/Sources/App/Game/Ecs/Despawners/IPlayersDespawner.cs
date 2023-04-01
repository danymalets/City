using Scellecs.Morpeh;
using Sources.Services.Di;

namespace Sources.App.Game.Ecs.Despawners
{
    public interface IPlayersDespawner : IService
    {
        void DespawnNpc(Entity playerEntity);
    }
}