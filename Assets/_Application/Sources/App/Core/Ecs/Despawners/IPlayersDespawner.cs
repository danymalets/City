using _Application.Sources.Utils.Di;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Despawners
{
    public interface IPlayersDespawner : IService
    {
        void DespawnNpc(Entity playerEntity);
    }
}