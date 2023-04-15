using Scellecs.Morpeh;
using Sources.Utils.Di;

namespace Sources.App.Core.Ecs.Despawners
{
    public interface IPlayersDespawner : IService
    {
        void DespawnNpc(Entity playerEntity);
    }
}