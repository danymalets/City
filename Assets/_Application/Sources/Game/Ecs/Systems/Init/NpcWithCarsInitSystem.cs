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
using Sources.Game.GameObjects.RoadSystem.Pathes;
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
        private Filter _carPathesFilter;

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
            _carPathesFilter = _world.Filter<CarsPathesTag>();
        }

        protected override void OnInitialize()
        {
            Entity npcPathes = _carPathesFilter.GetSingleton();
            Point[] points = npcPathes.Get<ListOf<Point>>().ToArray();

            points.RandomShuffle();

            // Vector3[] kus = GameObject.FindObjectsOfType<Transform>()
            //     .Where(t => t.gameObject.name == "ku").Select(t => t.position).ToArray();
            //
            // points = points.Where(p => kus.Any(k => Vector3.Distance(p.Position, k) <= 0.5f)).ToArray();
            
            foreach (Point point in points.Take(_simulationBalance.CarCount))
            {
                Quaternion carRotation = Quaternion.LookRotation(point.Direction);
                
                CarMonoEntity carPrefab = _assets.CarsAssets.GetRandomCar();
                
                Collider[] colliders = _physics.OverlapBox(point.Position + carRotation *
                    carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, carRotation, LayerMasks.CarsAndPlayers);

                if (colliders.Length > 0)
                {
                    continue;
                }

                Entity car = _factory.CreateCar(carPrefab, point.Position - carRotation * carPrefab.RootOffset, carRotation);

                car.Set(new CarMaxSpeed { Value = 3f });
                
                _physics.SyncTransforms();
                
                _factory.CreateNpcInCar(_assets.PlayersAssets.GetRandomPlayer(), car, point.Targets.First().FirstPathLine);
            }
        }
    }
}