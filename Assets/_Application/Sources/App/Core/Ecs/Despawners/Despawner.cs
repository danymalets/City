using _Application.Sources.CommonServices.PoolServices;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils;

namespace _Application.Sources.App.Core.Ecs.Despawners
{
    public abstract class Despawner
    {
        protected readonly DWorld _world;
        protected readonly IPoolDespawnerService _poolDespawner;
        
        protected Despawner()
        {
            _world = DiContainer.Resolve<DWorld>();
            _poolDespawner = DiContainer.Resolve<IPoolDespawnerService>();
        }
    }
}