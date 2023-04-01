using Sources.App.Game.Ecs.Factories;
using Sources.App.Infrastructure.Bootstrap;
using Sources.AssetsManager;
using Sources.Balance;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.Physics;

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class UserInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;

        private readonly Assets _assets;
        private readonly IPhysicsService _physics;
        private readonly PlayersBalance _playersBalance;
        private readonly CarsBalance _carsBalance;
        private readonly IPlayersFactory _playersFactory;

        public UserInitSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance.Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Balance.Balance>().CarsBalance;
            _levelContext = DiContainer.Resolve<LevelContext>();
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