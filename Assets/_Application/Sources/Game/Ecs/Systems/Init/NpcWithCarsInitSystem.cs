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
        private readonly SimulationBalance _simulationBalance;
        private Filter _carPathesFilter;
        private readonly PlayersBalance _playersBalance;
        private readonly CarsBalance _carsBalance;

        public NpcWithCarsInitSystem()
        {
            _assets = DiContainer.Resolve<Assets>();

            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;

            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
            _carPathesFilter = _world.Filter<CarsPathesTag>();
        }

        protected override void OnInitialize()
        {
            Entity npcPathes = _carPathesFilter.GetSingleton();
            
            Point[] points = npcPathes.GetList<ActiveSpawnPoints, Point>()
                .Concat(npcPathes.GetList<HorizonSpawnPoints, Point>()).ToArray();
            
            points.RandomShuffle();

            // Vector3[] kus = GameObject.FindObjectsOfType<Transform>()
            //     .Where(t => t.gameObject.name == "ku").Select(t => t.position).ToArray();
            //
            // points = points.Where(p => kus.Any(k => Vector3.Distance(p.Position, k) <= 0.5f)).ToArray();

            int count = 0;
            int reqCount = points.Length * _simulationBalance.CarsCountPer1000SpawnPoints / 1000;
            
            if (reqCount > 0)
            {
                foreach (Point point in points)
                {
                    Quaternion carRotation = Quaternion.LookRotation(point.Direction);

                    (CarType carType, CarColorType carColorType) = _carsBalance.GetRandomCar();
                    CarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(carType);

                    bool has = _physics.CheckBox(point.Position + carRotation *
                        carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, carRotation, LayerMasks.CarsAndPlayers);

                    if (!has)
                    {
                        Entity car = _factory.CreateCar(carPrefab, carColorType, point.Position - carRotation * carPrefab.RootOffset, carRotation);

                        car.Set(new CarMaxSpeed { Value = 3f });

                        _physics.SyncTransforms();

                        PlayerType playerType = _playersBalance.GetRandomPlayerType();
                        PlayerMonoEntity playerPrefab = _assets.PlayersAssets.GetPlayerPrefab(playerType);
                        
                        _factory.CreateNpcInCar(playerPrefab, car, point.Targets.First().FirstPathLine);

                        count++;
                        if (count == reqCount)
                            break;
                    }
                }
            }
        }
    }
}