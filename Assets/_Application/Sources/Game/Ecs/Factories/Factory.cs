using Scellecs.Morpeh;
using Sources.Game.Ecs.Aspects;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views.CarColors;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Components.Views.EnableDisable;
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
using ITransform = Sources.Game.Ecs.Components.Views.Transform.ITransform;

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
                .SetList<AllRoads, Road>(pathSystem.Roads)
                .SetList<AllCrossroads, Crossroads>(pathSystem.Crossroads)
                .AddList<AllSpawnPoints, Point>()
                .AddList<ActiveSpawnPoints, Point>()
                .AddList<HorizonSpawnPoints, Point>()
                .AddList<AllSpawnPoints, Point>()
                .AddList<AllPathLines, PathLine>();

        public Entity CreateCar(CarType carType, CarColorType carColor, Vector3 position, Quaternion rotation) => 
            CreateCar(_assets.CarsAssets.GetCarPrefab(carType), carColor, position, rotation);

        public Entity CreateRandomCar(Vector3 position, Quaternion rotation)
        {
            (CarType carType, CarColorType carColorType) = _balance.CarsBalance.GetRandomCar();
            return CreateCar(carType, carColorType, position, rotation);
        }

        public Entity CreateCar(CarMonoEntity carPrefab, CarColorType colorType, Vector3 position, Quaternion rotation)
        {
            return _world.CreateFromMonoPrefab(carPrefab)
                .Add<CarTag>()
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .SetupMonoIf<ICarMesh>(() => colorType != CarColorType.None, 
                    cc => cc.SetupColor(colorType))
                .Add<CarMotorCoefficient>()
                .Add<CarBreak>()
                .Add<SteeringAngle>()
                .Add<ForwardTrigger>()
                .Add<SmoothSteeringAngle>()
                .Set(new CarPassengers(4))
                .Set(new CarMaxSpeed { Value = Mathf.Infinity });
        }

        public PlayerMonoEntity GetRandomPlayerPrefab()
        {
            PlayerType playerType = _balance.PlayersBalance.GetRandomPlayerType();
            return _assets.PlayersAssets.GetPlayerPrefab(playerType);
        }

        public Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity)
        {
            return CreateUser(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupMono<IEnableableEntity>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity })
                .Set(new PlayerFollowTransform
                {
                    Position = carEntity.GetMono<ICarWheels>().RootPosition,
                    Rotation = carEntity.GetMono<ITransform>().Rotation
                });
        }

        public Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<UserTag>()
                .Add<UserCarInput>()
                .Add<UserPlayerInput>()
                .Set(new PlayerFollowTransform
                {
                    Position = position,
                    Rotation = rotation
                });

        public Entity CreateNpc(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<ForwardTrigger>()
                .Add<NpcTag>();

        public Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, position, rotation);
            
            npc.GetAspect<NpcStatusAspect>().SetPath(pathLine);
            
            return npc;
        }

        public Entity CreateNpcInCar(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupMono<IEnableableEntity>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity, Place = 0 });
            
            npc.GetAspect<NpcStatusAspect>().SetPath(pathLine);

            carEntity.Get<CarPassengers>().TakePlace(0, npc);
            
            return npc;
        }

        private Entity CreatePlayer(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            _world.CreateFromMonoPrefab(playerPrefab)
                .SetupMono<ITransform>(t => t.Position = position)
                .SetupMono<ITransform>(t => t.Rotation = rotation)
                .Set(new PlayerTargetAngle { Value = rotation.eulerAngles.y })
                .Set(new PlayerSmoothAngle { Value = rotation.eulerAngles.y })
                .Set(new RotationSpeed { Value = 45f })
                .Add<PlayerFollowTransform>()
                .Add<PlayerTargetSpeed>()
                .Add<PlayerSmoothSpeed>()
                .Add<PlayerTag>();

        public Entity CreateCamera()
        {
            return _world.CreateFromMono(_levelContext.CameraMonoEntity)
                .Add<CameraTag>()
                .Add<CameraYAngle>()
                .Add<CameraTargetBackDistance>()
                .Add<CameraTargetHeight>()
                .Add<CameraSmoothBackDistance>()
                .Add<CameraSmoothHeight>()
                .Add<CameraXTargetAngle>()
                .Add<CameraXSmoothAngle>()
                .Add<CameraSmoothFollowY>();
        }
    }
}