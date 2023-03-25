using Scellecs.Morpeh;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Despawners
{
    public interface ICarsDespawner : IService
    {
        void DespawnCar(Entity carEntity);
    }
}