using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Components.WorldStatus;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Services;
using Sources.App.Data;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Points;
using Sources.CommonServices.PhysicsServices;
using Sources.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class NpcsSpawnSystem : DUpdateSystem
    {
        private Filter _pathesFilter;
        private readonly SimulationBalance _simulationBalance;
        private Filter _npcFilter;
        private readonly IPhysicsService _physics;
        private readonly IPlayersFactory _playersFactory;
        private readonly ISimulationSettings _simulationSettings;
        private Filter _worldStatusFilter;

        public NpcsSpawnSystem()
        {
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();

            _physics = DiContainer.Resolve<IPhysicsService>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnInitFilters()
        {
            _worldStatusFilter = _world.Filter<WorldStatusTag>();
            _pathesFilter = _world.Filter<NpcsPathesTag>();
            _npcFilter = _world.Filter<NpcTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity pathesEntity = _pathesFilter.GetSingleton();

            int npcs = _npcFilter.Count();

            List<Point> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
            List<Point> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;

            int reqNpcs = (activePoints.Count + horizonPoints.Count) * _simulationSettings.NpcsPer1000SpawnPoints / 1000;

            List<Point> spawnPoints = new List<Point>(horizonPoints);
            
            if (_worldStatusFilter.GetSingleton()
                .Has<ActiveSimulationOn>())
            {
                spawnPoints.AddRange(activePoints);
            }
            
            spawnPoints.RandomShuffle();

            if (npcs >= reqNpcs)
                return;
            
            foreach (Point point in spawnPoints)
            {
                if (_playersFactory.TryCreateRandomNpc(point, out Entity createdEntity))
                {
                    _physics.SyncTransforms();

                    npcs++;

                    break;
                }
            }
        }
    }
}