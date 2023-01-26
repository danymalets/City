using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Generation
{
    public class HorizonCarsSpawnSystem : DUpdateSystem
    {
        private Filter _pathesFilter;
        private Filter _userFilter;
        private readonly SimulationBalance _simulationBalance;
        private Filter _npcWithCarsFilter;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;

        public HorizonCarsSpawnSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
        }

        protected override void OnInitFilters()
        {
            _pathesFilter = _world.Filter<CarsPathesTag>();
            _userFilter = _world.Filter<UserTag>();
            _npcWithCarsFilter = _world.Filter<NpcTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity pathesEntity = _pathesFilter.GetSingleton();

            int cars = _npcWithCarsFilter.Count();

            List<Point> activePoints = pathesEntity.GetList<ActiveSpawnPoints, Point>();
            List<Point> horizonPoints = pathesEntity.GetList<HorizonSpawnPoints, Point>();

            int reqCars = (activePoints.Count + horizonPoints.Count) * _simulationBalance.CarsCountPer1000SpawnPoints / 1000;

            Debug.Log($"cars: {reqCars}");

            if (cars < reqCars)
            {
                horizonPoints.RandomShuffle();

                CarMonoEntity carPrefab = _assets.CarsAssets.GetRandomCar();

                foreach (Point point in horizonPoints)
                {
                    Quaternion carRotation = Quaternion.LookRotation(point.Direction);

                    bool has = _physics.CheckBox(point.Position + carRotation *
                        carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, carRotation, LayerMasks.CarsAndPlayers);

                    if (!has)
                    {
                        Entity car = _factory.CreateCar(carPrefab, point.Position - carRotation * carPrefab.RootOffset, carRotation);

                        car.Set(new CarMaxSpeed { Value = 3f });

                        _factory.CreateNpcInCar(_assets.PlayersAssets.GetRandomPlayer(), car, point.Targets.First().FirstPathLine);

                        break;
                    }
                }
            }
        }
    }
}