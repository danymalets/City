using Scellecs.Morpeh;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class UserInitSystem : DInitializer
    {
        private readonly ILevelContextService _levelContext;

        private readonly ICarFactory _carFactory;
        private readonly IUserFactory _userFactory;
        private readonly IAssetsService _assets;
        private readonly IPhysicsService _physics;

        public UserInitSystem()
        {
            _carFactory = DiContainer.Resolve<ICarFactory>();
            _userFactory = DiContainer.Resolve<IUserFactory>();
            
            _levelContext = DiContainer.Resolve<ILevelContextService>();
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<IAssetsService>();
        }

        protected override void OnInitialize()
        {
            Entity car = _carFactory.CreateCar(_assets.CarMonoEntity,
                 _levelContext.UserSpawnPoint.Position, _levelContext.UserSpawnPoint.Rotation);

            _userFactory.CreateUser(car);
            
            _physics.SyncTransforms();
        }
    }
}