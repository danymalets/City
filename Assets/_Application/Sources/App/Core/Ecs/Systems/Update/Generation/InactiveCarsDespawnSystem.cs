using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Data.Simulations;
using Sources.App.Core.Ecs.Despawners;
using Sources.App.Services.AssetsServices.Common.Cars.CarsData;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class InactiveCarsDespawnSystem : CustomUpdateSystem
    {
        private Filter _carFilter;
        private readonly ICarsDespawner _carsDespawner;
        private Filter _carSimulationAreaFilter;

        public InactiveCarsDespawnSystem()
        {
            _carsDespawner = DiContainer.Resolve<ICarsDespawner>();
        }

        protected override void OnInitFilters()
        {
            _carFilter = _world.Filter<CarTag>().Without<AlwaysActive>().Build();
            _carSimulationAreaFilter = _world.Filter<CarsSimulationAreaTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            SimulationAreaData simulationAreaData = _carSimulationAreaFilter.GetSingleton()
                .Get<SimulationArea>().AreaData;

            foreach (Entity carEntity in _carFilter)
            {
                Vector3 carPosition = carEntity.GetRef<IWheelsSystem>().RootPosition;
                
                if (!simulationAreaData.IsInsideBig(carPosition))
                {
                    _carsDespawner.DespawnCar(carEntity);
                }
            }
        }
    }
}