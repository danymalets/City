using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Core.Ecs.Factories;
using _Application.Sources.App.Core.Services;
using _Application.Sources.App.Data.Common;
using _Application.Sources.App.Data.Constants;
using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.App.Data.Points;
using _Application.Sources.CommonServices.PhysicsServices;
using _Application.Sources.Utils.CommonUtils.Libs;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.AssetsServices;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Car
{
    public class IdleCarsSpawnSystem : DUpdateSystem
    {
        private Filter _userFilter;
        private readonly IIdleCarsSystem _idleCarsSystem;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly SimulationSettings _simulationSettings;
        private readonly ICarsFactory _carsFactory;

        public IdleCarsSpawnSystem()
        {
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
            _idleCarsSystem = DiContainer.Resolve<ILevelContext>().IdleCarsSystem;
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float sqrMinRadius = DMath.Sqr(_simulationSettings.NpcMinActiveRadius);
            float sqrMaxRadius = DMath.Sqr(_simulationSettings.NpcMaxActiveRadius);

            Vector3 userPosition = _userFilter.GetSingleton().Get<PlayerFollowTransform>().Position;

            foreach (IIdleCarSpawnPoint point in _idleCarsSystem.SpawnPoints)
            {
                if (!point.AliveCar.IsNullOrDisposed())
                    continue;
                
                float sqrDistance = DVector3.SqrDistance(userPosition, point.Position);
                if (sqrDistance > sqrMinRadius && sqrDistance < sqrMaxRadius)
                {
                    ICarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(point.CarType);

                    bool has = _physics.CheckBox(point.Position + point.Rotation *
                        carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, point.Rotation, 
                        LayerMasks.CarsAndPlayers);

                    if (!has)
                    {
                        Entity car = _carsFactory.CreateCar(carPrefab, point.CarColor,
                            point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);

                        point.AliveCar = car;
                        
                        break;
                    }
                }
            }
        }
    }
}