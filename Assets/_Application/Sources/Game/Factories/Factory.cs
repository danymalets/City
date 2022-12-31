using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Pool.Instantiators;

namespace Sources.Game.Factories
{
    public abstract class Factory
    {
        protected readonly IPoolInstantiatorService _poolInstantiator;
        protected readonly IAssetsService _assets;

        protected Factory()
        {
            _poolInstantiator = DiContainer.Resolve<IPoolInstantiatorService>();
            _assets = DiContainer.Resolve<IAssetsService>();
        }
    }
}