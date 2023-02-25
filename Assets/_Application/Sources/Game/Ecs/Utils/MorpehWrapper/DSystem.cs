using Scellecs.Morpeh;
using Sources.Game.Ecs.Factories;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Gizmoses;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DSystem
    {
        protected World _world;
        protected IFactory _factory;
        protected IGizmosService _gizmos;
        protected IDespawner _despawner;
        protected GizmosContext _updateGizmosContext;

        public void Setup(World world)
        {
            _world = world;
            _factory = DiContainer.Resolve<IFactory>();
            _despawner = DiContainer.Resolve<IDespawner>();
            _gizmos = DiContainer.Resolve<IGizmosService>();
            _updateGizmosContext = _gizmos.CreateContext();
        }
        
        public void Construct() =>
            OnConstruct();

        protected abstract void OnConstruct();

        public void Initialize()
        {
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }
    }
}