using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
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

        public NpcInitSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _simulationBalance = DiContainer.Resolve<Balance>()
                .SimulationBalance;
            _pathSystem = DiContainer.Resolve<LevelContext>()
                .NpcPathSystem;
        }

        protected override void OnInitFilters()
        {
            _npcPathesFilter = _world.Filter<NpcsPathesTag>();
        }

        protected override void OnInitialize()
        {
            Entity npcPathes = _npcPathesFilter.GetSingleton();
            
            Point[] points = npcPathes.GetList<ActiveSpawnPoints, Point>()
                .Concat(npcPathes.GetList<HorizonSpawnPoints, Point>()).ToArray();

            points.RandomShuffle();
            
            int count = 0;
            int reqCount = points.Length * _simulationBalance.NpcCountPer1000SpawnPoints / 1000;
            
            // Vector3[] kus = GameObject.FindObjectsOfType<Transform>()
            //     .Where(t => t.gameObject.name == "ku").Select(t => t.position).ToArray();
            //
            // points = points.Where(p => kus.Any(k => Vector3.Distance(p.Position, k) <= 0.5f)).ToArray();

            if (reqCount > 0)
            {

                foreach (Point point in points)
                {
                    Quaternion npcRotation = Quaternion.LookRotation(point.Direction);

                    PlayerMonoEntity playerPrefab = _assets.PlayersAssets.GetRandomPlayer();

                    bool has = _physics.CheckBox(point.Position + npcRotation *
                        playerPrefab.Center, playerPrefab.HalfExtents, npcRotation, LayerMasks.CarsAndPlayers);

                    if (!has)
                    {
                        Entity npc = _factory.CreateNpcOnPath(playerPrefab, point.Position, npcRotation,
                            point.Targets.GetRandom().FirstPathLine);

                        _physics.SyncTransforms();

                        count++;
                        if (count == reqCount)
                            break;
                    }
                }
            }
        }
    }
}