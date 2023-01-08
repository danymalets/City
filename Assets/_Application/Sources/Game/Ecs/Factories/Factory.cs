using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class Factory : IFactory
    {
        protected readonly World _world;
        protected readonly Assets _assets;
        private readonly LevelContext _levelContext;
        private readonly Balance _balance;

        public Factory(World world)
        {
            _world = world;
            _assets = DiContainer.Resolve<Assets>();
            _balance = DiContainer.Resolve<Balance>();
            _levelContext = DiContainer.Resolve<LevelContext>();
        }
        
        public Entity CreateCar(CarMonoEntity carPrefab, Vector3 position, Quaternion rotation)
        {
            Entity car = _world.CreateFromMonoPrefab(carPrefab)
                .Add<CarTag>()
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .Add<CarMotorCoefficient>()
                .Add<CarBreak>()
                .Add<SteeringAngle>()
                .Add<SmoothSteeringAngle>()
                .Set(new PlayerCarMaxSpeed{Value = Mathf.Infinity});
            
            return car;
        }
        
        public Entity CreateNpcInCar(Entity carEntity, Path path)
        {
            return CreateNpc()
                .SetupMono<IEnableDisableEntity>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity })
                .Set(new NpcCarPath { Path = path });
        }
        
        public Entity CreateUserInCar(Entity carEntity)
        {
            return CreateUser()
                .SetupMono<IEnableDisableEntity>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity });
        }

        public Entity CreateUser() =>
            CreatePlayer()
                .Add<UserTag>()
                .Add<UserCarInput>();

        public Entity CreateNpc() =>
            CreatePlayer()
                .Add<NpcTag>();
        
        private Entity CreatePlayer() =>
            _world.CreateFromMonoPrefab(_assets.PlayersAssets.GetRandomPlayer())
                .Add<PlayerTag>();

        public Entity CreateCamera()
        {
            return _world.CreateFromMono(_levelContext.CameraMonoEntity)
                .Add<CameraTag>();
        }
    }

    public interface IFactory : IService
    {
        Entity CreateCar(CarMonoEntity carPrefab, Vector3 position, Quaternion rotation);
        public Entity CreateNpcInCar(Entity carEntity, Path path);
        public Entity CreateUserInCar(Entity carEntity);
        Entity CreateCamera();
    }
}