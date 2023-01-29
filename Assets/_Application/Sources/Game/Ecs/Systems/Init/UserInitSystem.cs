using Scellecs.Morpeh;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game.Ecs.Systems.Init
{
    public class UserInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;

        private readonly Assets _assets;
        private readonly IPhysicsService _physics;
        private readonly PlayersBalance _playersBalance;
        private readonly CarsBalance _carsBalance;

        public UserInitSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
            _levelContext = DiContainer.Resolve<LevelContext>();
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
        }

        protected override void OnInitialize()
        {
            CarType carType = _carsBalance.GetRandomCarType();
            CarMonoEntity carPrefab = _assets.CarsAssets.GetCarPrefab(carType);

            Entity car = _factory.CreateCar(carPrefab,
                _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);

            PlayerType playerType = _playersBalance.GetRandomPlayerType();
            PlayerMonoEntity playerPrefab = _assets.PlayersAssets.GetPlayerPrefab(playerType);

            _factory.CreateUserInCar(playerPrefab, car);

            // _factory.CreateUser(_assets.PlayersAssets.GetRandomCarType(), 
            //     _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);

            _physics.SyncTransforms();
        }
    }
}