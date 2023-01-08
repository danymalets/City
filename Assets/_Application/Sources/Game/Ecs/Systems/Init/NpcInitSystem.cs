using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class NpcInitSystem : DInitializer
    {
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly PathSystem _pathSystem;

        public NpcInitSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _pathSystem = DiContainer.Resolve<LevelContext>()
                .NpcPathSystem;
        }

        protected override void OnInitialize()
        {
            List<IConnectingPoint> points = _pathSystem.RootPoints.ToList();
            points.RandomShuffle();
            
            foreach (IConnectingPoint point in points.Take(20))
            {
                PlayerMonoEntity playerPrefab = _assets.PlayersAssets.GetRandomPlayer();
                
                Collider[] colliders = _physics.OverlapBox(point.Position + point.Rotation *
                    playerPrefab.Center, playerPrefab.HalfExtents, point.Rotation, LayerMasks.CarsAndPlayers);

                if (colliders.Length > 0)
                {
                    continue;
                }

                Entity npc = _factory.CreateNpcOnPath(playerPrefab, point.Position, point.Rotation, point.GetRandomTargetPath());
                
                _physics.SyncTransforms();
            }
        }
    }
}