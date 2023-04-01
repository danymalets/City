using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Factories;
using Sources.AssetsManager;
using Sources.Data.RoadSystem.Pathes.Points;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.AssetsManager;
using Sources.Services.BalanceManager;
using Sources.Services.Physics;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.Generation
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
            _simulationBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().SimulationBalance;
            _playersBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CarsBalance;
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