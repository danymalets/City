using Scellecs.Morpeh;
using Sources.Utils.Di;

namespace Sources.App.Core.Ecs.Despawners
{
    public interface ICarsDespawner : IService
    {
        void DespawnCar(Entity carEntity);
    }
}