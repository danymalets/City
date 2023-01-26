using Scellecs.Morpeh;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public interface IDespawner : IService
    {
        public void DespawnCar(Entity carEntity);
        public void DespawnNpc(Entity carEntity);
    }
}