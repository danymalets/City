using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Data;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Points;
using Sources.CommonServices.PhysicsServices;
using Sources.ProjectServices.AssetsServices;
using Sources.ProjectServices.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class HorizonNpcSpawnSystem : DUpdateSystem
    {
        private Filter _pathesFilter;
        private readonly SimulationBalance _simulationBalance;
        private Filter _npcFilter;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly PlayersBalance _playersBalance;
        private readonly IPlayersFactory _playersFactory;

        public HorizonNpcSpawnSystem()
        {
            Balance balance = DiContainer.Resolve<Balance>();

            _simulationBalance = balance.SimulationBalance;
            _playersBalance = balance.PlayersBalance;

            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnConstruct()
        {
            _pathesFilter = _world.Filter<NpcsPathesTag>();
            _npcFilter = _world.Filter<NpcTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity pathesEntity = _pathesFilter.GetSingleton();

            int npcs = _npcFilter.Count();

            List<Point> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
            List<Point> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;

            int reqNpcs = (activePoints.Count + horizonPoints.Count) * _simulationBalance.NpcCountPer1000SpawnPoints / 1000;

            // Debug.Log($"players: {reqCars}");

            horizonPoints.RandomShuffle();

            PlayerType playerType = _playersBalance.GetRandomPlayerType();
            IPlayerMonoEntity playerPrefab = _assets.PlayersAssets.GetPlayerPrefab(playerType);

            foreach (Point point in horizonPoints)
            {
                if (npcs >= reqNpcs)
                    return;
                
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