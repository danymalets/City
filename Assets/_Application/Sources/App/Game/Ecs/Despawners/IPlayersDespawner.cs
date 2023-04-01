using Scellecs.Morpeh;
using Sources.Di;

namespace Sources.App.Game.Ecs.Despawners
{
    public interface IPlayersDespawner : IService
    {
        void DespawnNpc(Entity playerEntity);
    }
}