using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
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
    public class HorizonCarsSpawnSystem : DUpdateSystem
    {
        private Filter _pathesFilter;
        private readonly SimulationBalance _simulationBalance;
        private Filter _npcWithCarsFilter;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly PlayersBalance _playersBalance;
        private readonly CarsBalance _carsBalance;
        private readonly ICarsFactory _carsFactory;
        private readonly IPlayersFactory _playersFactory;

        public HorizonCarsSpawnSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnConstruct()
        {
            _pathesFilter = _world.Filter<CarsPathesTag>();
            _npcWithCarsFilter = _world.Filter<NpcTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity pathesEntity = _pathesFilter.GetSingleton();

            int cars = _npcWithCarsFilter.Count();

            List<Point> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
            List<Point> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;

            int reqCars = (activePoints.Count + horizonPoints.Count) * _simulationBalance.CarsCountPer1000SpawnPoints / 1000;
            
            horizonPoints.RandomShuffle();

            foreach (Point point in horizonPoints)
            {
                if (cars >= reqCars)
                    return;

                if (_carsFactory.TryCreateRandomCarOnPath(point, out Entity car))
                {
                    car.Set(new CarMaxSpeed { Value = 3f });

                    Entity player = _playersFactory.CreateRandomNpcInCarOnPath(car, point);
                    cars++;

                    break;
                }
            }
        }
    }
}