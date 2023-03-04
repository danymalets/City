using Scellecs.Morpeh;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Bootstrap.IdleCarSpawns;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Car
{
    public class IdleCarsSpawnSystem : DUpdateSystem
    {
        private Filter _userFilter;
        private readonly IdleCarsSystem _idleCarsSystem;
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly SimulationBalance _simulationBalance;

        public IdleCarsSpawnSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _idleCarsSystem = DiContainer.Resolve<LevelContext>().IdleCarsSystem;
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float sqrMinRadius = DMath.Sqr(_simulationBalance.NpcMinActiveRadius);
            float sqrMaxRadius = DMath.Sqr(_simulationBalance.NpcMaxActiveRadius);

            Vector3 userPosition = _userFilter.GetSingleton().Get<PlayerFollowTransform>().Position;

            foreach (IdleCarSpawnPoint point in _idleCarsSystem.SpawnPoints)
            {
                if (!point.AliveCar.IsNullOrDisposed())
                    continue;
                
                float sqrDistance = DVector3.SqrDistance(userPosition, point.Position);
                if (sqrDistance > sqrMinRadius && sqrDistance < sqrMaxRadius)
                {
                    CarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(point.CarType);

                    bool has = _physics.CheckBox(point.Position + point.Rotation *
                        carPrefab.CenterRelatedRootPoint, carPrefab.HalfExtents, point.Rotation, 
                        LayerMasks.CarsAndPlayers);

                    if (!has)
                    {
                        Entity car = _factory.CreateCar(carPrefab, point.CarColor,
                            point.Position - point.Rotation * carPrefab.RootOffset, point.Rotation);

                        point.AliveCar = car;
                        
                        break;
                    }
                }
            }
        }
    }
}