using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Pool.Instantiators;

namespace Sources.Game.Factories
{
    public abstract class Factory
    {
        protected readonly IPoolSpawnerService PoolSpawner;
        protected readonly IAssetsService _assets;

        protected Factory()
        {
            PoolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _assets = DiContainer.Resolve<IAssetsService>();
        }
    }
}