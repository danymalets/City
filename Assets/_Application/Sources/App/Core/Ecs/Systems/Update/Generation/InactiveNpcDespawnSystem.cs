using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.App.Core.Services;
using Sources.App.Data;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class InactiveNpcDespawnSystem : DUpdateSystem
    {
        private Filter _npcFilter;
        private Filter _userFilter;
        private readonly IPlayersDespawner _playersDespawner;
        private Filter _carsSimulationAreaFilter;
        private Filter _npcsSimulationAreaFilter;

        public InactiveNpcDespawnSystem()
        {
            _playersDespawner = DiContainer.Resolve<IPlayersDespawner>();
        }

        protected override void OnInitFilters()
        {
            _npcsSimulationAreaFilter = _world.Filter<NpcsSimulationAreaTag>();
            _carsSimulationAreaFilter = _world.Filter<CarsSimulationAreaTag>();
            _npcFilter = _world.Filter<NpcTag>().Without<AlwaysActive>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            SimulationAreaData npcsSimulationAreaData = _npcsSimulationAreaFilter.GetSingleton()
                .Get<SimulationArea>().AreaData;
            
            SimulationAreaData carsSimulationAreaData = _carsSimulationAreaFilter.GetSingleton()
                .Get<SimulationArea>().AreaData;

            foreach (Entity npcEntity in _npcFilter)
            {
                Vector3 npcPosition = npcEntity.GetAspect<PlayerPointAspect>().GetPosition();

                SimulationAreaData simulationArea = npcEntity.Has<PlayerInCar>()
                    ? carsSimulationAreaData
                    : npcsSimulationAreaData;
                
                if (!simulationArea.IsInsideBig(npcPosition))
                {
                    _playersDespawner.DespawnPlayer(npcEntity);
                }
            }
        }
    }
}