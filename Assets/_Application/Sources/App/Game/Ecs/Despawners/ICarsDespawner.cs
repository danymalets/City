using Scellecs.Morpeh;
using Sources.Services.Di;

namespace Sources.App.Game.Ecs.Despawners
{
    public interface ICarsDespawner : IService
    {
        void DespawnCar(Entity carEntity);
    }
}