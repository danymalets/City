using Sources.App.Infrastructure.Bootstrap;
using Sources.AssetsManager;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils;
using Sources.Services.Pool;

namespace Sources.App.Game.Ecs.Factories
{
    public abstract class Factory
    {
        protected readonly DWorld _world;
        protected readonly Assets _assets;
        protected readonly LevelContext _levelContext;
        protected readonly Balance.Balance _balance;
        protected readonly IPoolSpawnerService _poolSpawner;

        protected Factory()
        {
            _world = DiContainer.Resolve<DWorld>();
            _assets = DiContainer.Resolve<Assets>();
            _balance = DiContainer.Resolve<Balance.Balance>();
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _levelContext = DiContainer.Resolve<LevelContext>();
        }
    }
}