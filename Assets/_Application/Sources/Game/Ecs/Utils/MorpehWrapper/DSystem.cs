using Scellecs.Morpeh;
using Sources.Game.Ecs.Factories;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Gizmoses;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DSystem
    {
        protected World _world;
        protected IGizmosService _gizmos;
        protected GizmosContext _updateGizmosContext;

        public void Setup(World world)
        {
            _world = world;
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