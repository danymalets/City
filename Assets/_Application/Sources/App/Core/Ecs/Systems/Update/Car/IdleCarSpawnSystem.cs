using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Services;
using Sources.App.Data.Common;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.CommonServices.PhysicsServices;
using Sources.ProjectServices.AssetsServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Car
{
    public class IdleCarsSpawnSystem : DUpdateSystem
    {
        private Filter _userFilter;
        private readonly IIdleCarsSystem _idleCarsSystem;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly ISimulationSettings _simulationSettings;
        private readonly ICarsFactory _carsFactory;

        public IdleCarsSpawnSystem()
        {
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
            _idleCarsSystem = DiContainer.Resolve<ILevelContext>().IdleCarsSystem;
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            // float sqrMinRadius = DMath.Sqr(_simulationSettings.NpcsRadius);
            // float sqrMaxRadius = DMath.Sqr(_simulationSettings.NpcMaxActiveRadius);
            //
            // Vector3 userPosition = _userFilter.GetSingleton().GetAspect<PlayerPointAspect>().GetPosition();
            //
            // foreach (IIdleCarSpawnPoint point in _idleCarsSystem.SpawnPoints)
            // {
            //     if (!point.AliveCar.IsNullOrDisposed())
            //         continue;
            //     
            //     float sqrDistance = DVector3.SqrDistance(userPosition, point.Position);
            //     if (sqrDistance > sqrMinRadius && sqrDistance < sqrMaxRadius)
            //     {
            //         ICarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(point.CarType);
            //
            //         bool has = _physics.CheckBox(point.Position + point.Rotation *
            //             carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, point.Rotation, 
            //             LayerMasks.CarsAndPlayers);
            //
            //         if (!has)
            //         {
            //             Entity car = _carsFactory.CreateCar(carPrefab, point.CarColor,
            //                 point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);
            //
            //             point.AliveCar = car;
            //             
            //             break;
            //         }
            //     }
            // }
        }
    }
}