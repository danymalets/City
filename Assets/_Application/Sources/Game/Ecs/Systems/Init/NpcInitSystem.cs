using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class NpcInitSystem : DInitializer
    {
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly IPathSystem _pathSystem;
        private readonly SimulationBalance _simulationBalance;
        private Filter _npcPathesFilter;
        private readonly PlayersBalance _playersBalance;
        private readonly IPlayersFactory _playersFactory;

        public NpcInitSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
            _pathSystem = DiContainer.Resolve<LevelContext>().NpcPathSystem;
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnConstruct()
        {
            _npcPathesFilter = _world.Filter<NpcsPathesTag>();
        }

        protected override void OnInitialize()
        {
            Entity npcPathes = _npcPathesFilter.GetSingleton();

            Point[] points = npcPathes.Get<ActiveSpawnPoints>().List
                .Concat(npcPathes.Get<HorizonSpawnPoints>().List).ToArray();

            points.RandomShuffle();

            int count = 0;
            int reqCount = points.Length * _simulationBalance.NpcCountPer1000SpawnPoints / 1000;

            foreach (Point point in points)
            {
                if (count == reqCount)
                    break;
                
                if (_playersFactory.TryCreateRandomNpc(point, out Entity createdEntity))
                {
                    _physics.SyncTransforms();

                    count++;
                }
            }
        }
    }
}