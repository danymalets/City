using Scellecs.Morpeh;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Despawners
{
    public interface ICarsDespawner : IService
    {
        void DespawnCar(Entity carEntity);
    }
}