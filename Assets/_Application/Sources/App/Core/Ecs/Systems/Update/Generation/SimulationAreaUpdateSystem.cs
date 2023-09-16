using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.SimulationCamera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.App.Data;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class SimulationAreaUpdateSystem : DUpdateSystem
    {
        private Filter _simulationAreaFilter;
        private Filter _simulationCameraFilter;

        protected override void OnInitFilters()
        {
            _simulationCameraFilter = _world.Filter<SimulationCameraTag>();
            _simulationAreaFilter = _world.Filter<SimulationAreaTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity simulationCamera = _simulationCameraFilter.GetSingleton();
            Vector2 simulationCameraPosition = simulationCamera.Get<SimulationCameraPosition>().Position;
            Vector2 simulationCameraNormalDirection = simulationCamera.Get<SimulationCameraDirection>().NormalDirection;
            
            foreach (Entity simulationAreaEntity in _simulationAreaFilter)
            {
                SimulationBordersData simulationBorders = simulationAreaEntity.Get<SimulationBorders>().BordersData;
                ref SimulationArea simulationArea = ref simulationAreaEntity.Get<SimulationArea>();
                
                simulationArea.AreaData = new SimulationAreaData(simulationCameraPosition,
                    simulationCameraNormalDirection, simulationBorders);
            }
        }
    }
}