using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Collections;
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

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class NpcWithCarsInitSystem : DInitializer
    {
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly SimulationBalance _simulationBalance;
        private Filter _carPathesFilter;
        private readonly PlayersBalance _playersBalance;
        private readonly CarsBalance _carsBalance;
        private readonly ICarsFactory _carsFactory;
        private readonly IPlayersFactory _playersFactory;

        public NpcWithCarsInitSystem()
        {
            _assets = DiContainer.Resolve<Assets>();

            _simulationBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().SimulationBalance;
            _playersBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CarsBalance;

            _physics = DiContainer.Resolve<IPhysicsService>();
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnConstruct()
        {
            _carPathesFilter = _world.Filter<CarsPathesTag>();
        }

        protected override void OnInitialize()
        {
            Entity npcPathes = _carPathesFilter.GetSingleton();

            Point[] points = npcPathes.Get<ActiveSpawnPoints>().List
                .Concat(npcPathes.Get<HorizonSpawnPoints>().List).ToArray();

            points.RandomShuffle();

            int count = 0;
            int reqCount = points.Length * _simulationBalance.CarsCountPer1000SpawnPoints / 1000;

            foreach (Point point in points)
            {
                if (count == reqCount)
                    break;

                if (_carsFactory.TryCreateRandomCarOnPath(point, out Entity car))
                {
                    car.Set(new CarMaxSpeed { Value = 3f });

                    _physics.SyncTransforms();

                    Entity player = _playersFactory.CreateRandomNpcInCarOnPath(car, point);

                    count++;
                }
            }
        }
    }
}