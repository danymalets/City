using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Generation
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
            PlayerMonoEntity playerPrefab = _assets.PlayersAssets.GetPlayerPrefab(playerType);

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