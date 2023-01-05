using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Pool.Instantiators;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class CarFactory : ICarFactory
    {
        private readonly EcsWorld _world;
        private readonly IPoolSpawnerService _poolSpawner;
        private readonly MonoEntity _userCarMonoEntity;

        public CarFactory(EcsWorld world)
        {
            _world = world;

            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _userCarMonoEntity = DiContainer.Resolve<IAssetsService>().UserCarMonoEntity;
        }

        public EcsEntity CreateCar(Vector3 position, Quaternion rotation)
        {
            EcsEntity carEntity = _world.NewEntity();

            MonoEntity monoEntity = _poolSpawner.Spawn(_userCarMonoEntity, position, rotation);
            
            monoEntity.Setup(carEntity);

            carEntity.Add<Physical>();

            return carEntity;
        }
    }
}