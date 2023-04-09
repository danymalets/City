using Sources.App.Game.Ecs.Factories;
using Sources.Data;
using Sources.Data.Common;
using Sources.Services.AssetsManager;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Services.Physics;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class UserInitSystem : DInitializer
    {
        private readonly ILevelContext _levelContext;

        private readonly Assets _assets;
        private readonly IPhysicsService _physics;
        private readonly CarsBalance _carsBalance;
        private readonly IPlayersFactory _playersFactory;

        public UserInitSystem()
        {
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
            _levelContext = DiContainer.Resolve<ILevelContext>();
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnInitialize()
        {
            // Entity car = _factory.CreateRandomCar(
            //     _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);
            
            // _factory.CreateUserInCar(playerPrefab, car);

            _playersFactory.CreateUser(_assets.PlayersAssets.GetPlayerPrefab(PlayerType.Gangster), 
                _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);

            _physics.SyncTransforms();
        }
    }
}