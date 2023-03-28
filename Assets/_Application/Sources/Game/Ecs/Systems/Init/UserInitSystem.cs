using Scellecs.Morpeh;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
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
        private readonly IPlayersFactory _playersFactory;

        public UserInitSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
            _carsBalance = DiContainer.Resolve<Balance>().CarsBalance;
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