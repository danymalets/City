using _Application.Sources.App.Core.Ecs.Factories;
using _Application.Sources.App.Data;
using _Application.Sources.App.Data.Common;
using _Application.Sources.CommonServices.PhysicsServices;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Sources.ProjectServices.AssetsServices;
using Sources.ProjectServices.BalanceServices;

namespace _Application.Sources.App.Core.Ecs.Systems.Init
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