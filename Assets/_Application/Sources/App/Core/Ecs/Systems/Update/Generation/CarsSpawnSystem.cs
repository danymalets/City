using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Components.WorldStatus;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Services;
using Sources.App.Data.Points;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class CarsSpawnSystem : DUpdateSystem
    {
        private readonly ICarsFactory _carsFactory;
        private readonly IPlayersFactory _playersFactory;
        private readonly ISimulationSettings _simulationSettings;
        
        private Filter _pathesFilter;
        private Filter _worldStatusFilter;
        private Filter _npcWithCarsFilter;

        public CarsSpawnSystem()
        {
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnInitFilters()
        {
            _worldStatusFilter = _world.Filter<WorldStatusTag>();
            _pathesFilter = _world.Filter<CarsPathesTag>();
            _npcWithCarsFilter = _world.Filter<NpcTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity pathesEntity = _pathesFilter.GetSingleton();

            int cars = _npcWithCarsFilter.Count();

            List<Point> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
            List<Point> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;

            int reqCars = (activePoints.Count + horizonPoints.Count) * _simulationSettings.CarsPer1000SpawnPoints / 1000;

            List<Point> spawnPoints = new List<Point>(horizonPoints);;

            if (_worldStatusFilter.GetSingleton()
                .Has<ActiveSimulationOn>())
            {
                spawnPoints.AddRange(activePoints);
            }
            
            spawnPoints.RandomShuffle();
            
            if (cars >= reqCars)
                return;
            
            foreach (Point point in spawnPoints)
            {
                if (_carsFactory.TryCreateRandomCarOnPath(point, false, out Entity car))
                {
                    car.Set(new CarMaxSpeed { Value = 3f });

                    _playersFactory.CreateRandomNpcInCarOnPath(car, point);
                    cars++;
                    
                    break;
                }
            }
        }
    }
}