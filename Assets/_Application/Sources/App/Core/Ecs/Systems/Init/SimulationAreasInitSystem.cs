using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Services;
using Sources.App.Data;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class SimulationAreasInitSystem : DInitializer
    {
        private readonly ISimulationAreasFactory _simulationAreasFactory;
        private readonly ISimulationSettings _simulationSettings;

        public SimulationAreasInitSystem()
        {
            _simulationAreasFactory = DiContainer.Resolve<ISimulationAreasFactory>();
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
        }

        protected override void OnInitialize()
        {
            _simulationAreasFactory.CreateSimulationArea<NpcsSimulationAreaTag>(new SimulationBordersData(
                _simulationSettings.NpcsRadius, 
                _simulationSettings.BackNpcDistance, 
                _simulationSettings.Delta));
            
            _simulationAreasFactory.CreateSimulationArea<CarsSimulationAreaTag>(new SimulationBordersData(
                _simulationSettings.CarsRadius, 
                _simulationSettings.BackCarDistance, 
                _simulationSettings.Delta));
            
            
        }
    }
}