using Sources.App.DMorpeh.MorpehUtils;
using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.AssetsManager;
using Sources.App.Infrastructure.Services.Balance;
using Sources.App.Infrastructure.Services.Pool;

namespace Sources.App.Game.Ecs.Factories
{
    public abstract class Factory
    {
        protected readonly DWorld _world;
        protected readonly Assets _assets;
        protected readonly LevelContext _levelContext;
        protected readonly Balance _balance;
        protected readonly IPoolSpawnerService _poolSpawner;

        protected Factory()
        {
            _world = DiContainer.Resolve<DWorld>();
            _assets = DiContainer.Resolve<Assets>();
            _balance = DiContainer.Resolve<Balance>();
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _levelContext = DiContainer.Resolve<LevelContext>();
        }
    }
}