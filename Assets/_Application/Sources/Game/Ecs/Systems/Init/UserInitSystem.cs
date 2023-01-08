using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;

namespace Sources.Game.Ecs.Systems.Init
{
    public class UserInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;

        private readonly Assets _assets;
        private readonly IPhysicsService _physics;

        public UserInitSystem()
        {
            _levelContext = DiContainer.Resolve<LevelContext>();
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
        }

        protected override void OnInitialize()
        {
            Entity car = _factory.CreateCar(_assets.CarsAssets.GetRandomCar(),
                 _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);

            _factory.CreateUserInCar(_assets.PlayersAssets.GetRandomPlayer(), car);
            
            _physics.SyncTransforms();
        }
    }
}