using Sources.Data.Common;
using Sources.Services.AssetsManager;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Services.Pool;
using Sources.Utils.DMorpeh.MorpehUtils;

namespace Sources.App.Game.Ecs.Factories
{
    public abstract class Factory
    {
        protected readonly DWorld _world;
        protected readonly Assets _assets;
        protected readonly ILevelContext _levelContext;
        protected readonly Balance _balance;
        protected readonly IPoolSpawnerService _poolSpawner;

        protected Factory()
        {
            _world = DiContainer.Resolve<DWorld>();
            _assets = DiContainer.Resolve<Assets>();
            _balance = DiContainer.Resolve<Balance>();
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _levelContext = DiContainer.Resolve<ILevelContext>();
        }
    }
}