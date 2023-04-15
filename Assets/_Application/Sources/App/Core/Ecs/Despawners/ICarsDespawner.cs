using _Application.Sources.Utils.Di;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Despawners
{
    public interface ICarsDespawner : IService
    {
        void DespawnCar(Entity carEntity);
    }
}