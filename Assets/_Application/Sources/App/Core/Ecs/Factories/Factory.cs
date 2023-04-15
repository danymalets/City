using _Application.Sources.App.Data.Common;
using _Application.Sources.CommonServices.PoolServices;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.ProjectServices.AssetsServices;
using Sources.ProjectServices.BalanceServices;

namespace _Application.Sources.App.Core.Ecs.Factories
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