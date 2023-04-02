using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Factories;
using Sources.Data.Constants;
using Sources.Data.MonoViews;
using Sources.Monos;
using Sources.Services.AssetsManager;
using Sources.Services.Di;
using Sources.Services.Physics;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class IdleCarsInitSystem : DInitializer
    {
        private Filter _userFilter;
        private readonly IIdleCarsSystem _idleCarsSystem;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly SimulationSettings _simulationSettings;
        private readonly ICarsFactory _carsFactory;

        public IdleCarsInitSystem()
        {
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
            _idleCarsSystem = DiContainer.Resolve<ILevelContext>().IdleCarsSystem;
            _carsFactory = DiContainer.Resolve<ICarsFactory>();
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnInitialize()
        {
            float sqrMaxRadius = DMath.Sqr(_simulationSettings.NpcMaxActiveRadius);

            Vector3 userPosition = _userFilter.GetSingleton().Get<PlayerFollowTransform>().Position;

            foreach (IIdleCarSpawnPoint point in _idleCarsSystem.SpawnPoints)
            {
                if (DVector3.SqrDistance(userPosition, point.Position) < sqrMaxRadius)
                {
                    ICarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(point.CarType);

                    bool has = _physics.CheckBox(point.Position + point.Rotation *
                        carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, point.Rotation, LayerMasks.CarsAndPlayers);

                    if (!has)
                    {
                        Entity car = _carsFactory.CreateCar(carPrefab, point.CarColor,
                            point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);
                        
                        point.AliveCar = car;
                    }
                }
            }
        }
    }
}