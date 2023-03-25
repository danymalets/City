using Scellecs.Morpeh;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.Pool;

namespace Sources.Game.Ecs.Factories
{
    public abstract class Factory
    {
        protected readonly World _world;
        protected readonly Assets _assets;
        protected readonly LevelContext _levelContext;
        protected readonly Balance _balance;
        protected readonly IPoolSpawnerService _poolSpawner;

        protected Factory(World world)
        {
            _world = world;
            _assets = DiContainer.Resolve<Assets>();
            _balance = DiContainer.Resolve<Balance>();
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _levelContext = DiContainer.Resolve<LevelContext>();
        }
    }
}