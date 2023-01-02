using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Pool.Instantiators;

namespace Sources.Game.Factories
{
    public abstract class Factory
    {
        protected readonly IPoolSpawnerService _poolSpawner;
        protected readonly IAssetsService _assets;

        protected Factory()
        {
            _poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            _assets = DiContainer.Resolve<IAssetsService>();
        }
    }
}