using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.EnableDisable;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
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

        public Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent =>
            _world.CreateEntity()
                .Add<TTag>()
                .Add<PathesTag>()
                .Set(new ListOf<Road>(pathSystem.Roads))
                .Set(new ListOf<Crossroads>(pathSystem.Crossroads))
                .Set(new ListOf<Point>(0))
                .Set(new ListOf<PathLine>(0));
        
        public Entity CreateCar(CarMonoEntity carPrefab, Vector3 position, Quaternion rotation)
        {
            Entity car = _world.CreateFromMonoPrefab(carPrefab)
                .Add<CarTag>()
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .Add<CarMotorCoefficient>()
                .Add<CarBreak>()
                .Add<SteeringAngle>()
                .Add<ForwardTrigger>()
                .Add<SmoothSteeringAngle>()
                .Set(new CarMaxSpeed{Value = Mathf.Infinity});
            
            return car;
        }
        
        public Entity CreateNpcInCar(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine)
        {
            return CreateNpc(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupMono<IEnableDisableEntity>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity })
                .Set(new NpcOnPath { PathLine = pathLine })
                .Set(new ListOf<TurnData>(0))
                .Set(new QueueOf<ChoiceData>(0));
        }
        
        public Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity)
        {
            return CreateUser(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupMono<IEnableDisableEntity>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity });
        }
        
        public Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<UserTag>()
                .Add<UserCarInput>()
                .Add<UserPlayerInput>();

        private Entity CreateNpc(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<ForwardTrigger>()
                .Add<NpcTag>();
        
        public Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine) =>
            CreateNpc(playerPrefab, position, rotation)
                .Set(new NpcOnPath { PathLine = pathLine });
        
        private Entity CreatePlayer(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            _world.CreateFromMonoPrefab(playerPrefab)
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .Set(new TargetAngle{ Value = rotation.eulerAngles.y})
                .Set(new SmoothAngle{ Value = rotation.eulerAngles.y})
                .Set(new RotationSpeed { Value = 45f })
                .Add<PlayerSpeed>()
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
        Entity CreateNpcInCar(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
        Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateCamera();
        Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
    }
}