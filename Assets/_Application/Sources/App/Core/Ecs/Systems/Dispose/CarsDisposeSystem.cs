using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Dispose
{
    public class CarsDisposeSystem : DDisposer
    {
        private Filter _filter;
        private readonly ICarsDespawner _carsDespawner;

        public CarsDisposeSystem()
        {
            _carsDespawner = DiContainer.Resolve<ICarsDespawner>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<CarTag>();
        }

        protected override void OnDispose()
        {
            foreach (Entity carEntity in _filter)
            {
                _carsDespawner.DespawnCar(carEntity);
            }
        }
    }
}