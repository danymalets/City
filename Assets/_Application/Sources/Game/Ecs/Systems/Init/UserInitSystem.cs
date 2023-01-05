using Leopotam.Ecs;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;

namespace Sources.Game.Ecs.Systems.Init
{
    public class UserInitSystem : IEcsInitSystem
    {
        private readonly MonoEntity _userCarEntity;
        private readonly ILevelContextService _levelContext;

        private CarFactory _carFactory;
        private UserFactory _userFactory;
        
        public UserInitSystem()
        {
            _userCarEntity = DiContainer.Resolve<IAssetsService>().UserCarMonoEntity;
            _levelContext = DiContainer.Resolve<ILevelContextService>();
        }

        public void Init()
        {
            EcsEntity car = _carFactory.CreateCar(
                _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);

            EcsEntity user = _userFactory.CreateUser(car);
        }
    }
}