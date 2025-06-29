using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Components.WorldStatus;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Services.Simulation;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Services.PhysicsServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class NpcsSpawnSystem : CustomUpdateSystem
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
            _worldStatusFilter = _world.Filter<WorldStatusTag>().Build();
            _pathesFilter = _world.Filter<NpcsPathesTag>().Build();
            _npcFilter = _world.Filter<NpcTag>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity pathesEntity = _pathesFilter.GetSingleton();

            int npcs = _npcFilter.GetLengthSlow();

            List<PathPoint> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
            List<PathPoint> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;

            int reqNpcs = (activePoints.Count + horizonPoints.Count) * _simulationSettings.NpcsPer1000SpawnPoints / 1000;

            List<PathPoint> spawnPoints = new List<PathPoint>(horizonPoints);
            
            if (_worldStatusFilter.GetSingleton()
                .Has<ActiveSimulationOn>())
            {
                spawnPoints.AddRange(activePoints);
            }
            
            spawnPoints.RandomShuffle();

            if (npcs >= reqNpcs)
                return;
            
            foreach (PathPoint point in spawnPoints)
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