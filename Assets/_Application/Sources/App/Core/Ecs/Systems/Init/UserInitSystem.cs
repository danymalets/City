using Sources.App.Core.Ecs.Factories;
using Sources.App.Data;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.Services.PhysicsServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class UserInitSystem : DInitializer
    {
        private readonly ILevelContext _levelContext;

        private readonly Assets _assets;
        private readonly IPhysicsService _physics;
        private readonly IPlayersFactory _playersFactory;

        public UserInitSystem()
        {
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