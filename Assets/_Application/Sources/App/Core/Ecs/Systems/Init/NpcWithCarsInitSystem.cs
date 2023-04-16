using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Data.Points;
using Sources.CommonServices.PhysicsServices;
using Sources.ProjectServices.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class NpcWithCarsInitSystem : DInitializer
    {
        private readonly IPhysicsService _physics;
        private readonly SimulationBalance _simulationBalance;
        private Filter _carPathesFilter;
        private readonly ICarsFactory _carsFactory;
        private readonly IPlayersFactory _playersFactory;

        public NpcWithCarsInitSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _physics = DiContainer.Resolve<IPhysicsService>();
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnInitFilters()
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