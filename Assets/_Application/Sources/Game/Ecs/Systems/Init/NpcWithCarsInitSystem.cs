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
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class NpcWithCarsInitSystem : DInitializer
    {
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly IPathSystem _pathSystem;
        private readonly SimulationBalance _simulationBalance;

        public NpcWithCarsInitSystem()
        {
            _assets = DiContainer.Resolve<Assets>();
            
            _pathSystem = DiContainer.Resolve<LevelContext>()
                .CarsPathSystem;
            
            _simulationBalance = DiContainer.Resolve<Balance>()
                .SimulationBalance;

            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
        }

        protected override void OnInitialize()
        {
            List<IConnectingPoint> points = _pathSystem.RootPoints.ToList();
            points.RandomShuffle();
            
            foreach (IConnectingPoint point in points.Take(_simulationBalance.CarCount))
            {
                CarMonoEntity carPrefab = _assets.CarsAssets.GetRandomCar();
                
                Collider[] colliders = _physics.OverlapBox(point.Position + point.Rotation *
                    carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, point.Rotation, LayerMasks.CarsAndPlayers);

                if (colliders.Length > 0)
                {
                    continue;
                }

                Entity car = _factory.CreateCar(carPrefab, point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);

                car.Set(new PlayerCarMaxSpeed { Value = 3f });
                
                _physics.SyncTransforms();
                
                _factory.CreateNpcInCar(_assets.PlayersAssets.GetRandomPlayer(), car, point.GetRandomTargetPath());
            }
        }
    }
}