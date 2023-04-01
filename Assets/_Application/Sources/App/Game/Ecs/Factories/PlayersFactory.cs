using System.Linq;
using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Components.Monos;
using Sources.App.Game.Components.Old.PlayerAnimators;
using Sources.App.Game.Components.Views;
using Sources.App.Game.Constants;
using Sources.App.Game.Ecs.Aspects;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Components.User;
using Sources.App.Game.Ecs.DefaultComponents;
using Sources.App.Game.Ecs.DefaultComponents.Monos;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.AssetsManager;
using Sources.App.Infrastructure.Services.Balance;
using Sources.App.Infrastructure.Services.Physics;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Factories
{
    public class PlayersFactory : Factory, IPlayersFactory
    {
        private readonly PlayersBalance _playersBalance;
        private readonly IPhysicsService _physics;

        public PlayersFactory() : base()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        public PlayerMonoEntity GetRandomPlayerPrefab()
        {
            PlayerType playerType = _balance.PlayersBalance.GetRandomPlayerType();
            return _assets.PlayersAssets.GetPlayerPrefab(playerType);
        }

        public Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity)
        {
            return CreateUser(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupAccessible<EnableableGameObject>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity })
                .Set(new PlayerFollowTransform
                {
                    Position = carEntity.GetAccess<WheelsSystem>().RootPosition,
                    Rotation = carEntity.GetAccess<ITransform>().Rotation
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

        public bool TryCreateRandomNpc(Point point, out Entity createdEntity)
        {
            PlayerMonoEntity playerPrefab = GetRandomPlayerPrefab();
            
            SafeCapsuleCollider capsule = playerPrefab.PlayerBorders.SafeCapsuleCollider;

            bool has = _physics.CheckCapsule(capsule.Start + point.Position, capsule.End + point.Position,
                capsule.Radius, LayerMasks.CarsAndPlayers);

            if (has)
            {
                createdEntity = default;
                return false;
            }
            else
            {
                createdEntity = CreateNpcOnPath(playerPrefab, point.Position, point.Rotation,
                    point.Targets.GetRandom().FirstPathLine);
                return true;
            }
        }

        public Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, position, rotation);
            
            npc.GetAspect<NpcStatusAspect>().SetPath(pathLine);
            
            return npc;
        }

        public Entity CreateNpcInCarOnPath(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine)
        {
            playerPrefab.gameObject.Enable();
            
            Entity npc = CreateNpc(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupAccessible<IEnableableGameObject>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity, Place = 0 });
            
            npc.GetAspect<NpcStatusAspect>().SetPath(pathLine);

            carEntity.Get<CarPassengers>().TakePlace(0, npc);
            
            return npc;
        }

        public Entity CreateRandomNpcInCarOnPath(Entity car, Point point) => 
            CreateNpcInCarOnPath(GetRandomPlayerPrefab(), car, point.Targets.First().FirstPathLine);

        private Entity CreatePlayer(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation)
        {
            PlayerMonoEntity playerMonoEntity = _poolSpawner.Spawn(playerPrefab, position, rotation);

            return _world.CreateFromMono(playerMonoEntity)
                .SetAccess<IEnableableGameObject>(playerMonoEntity.EnableableGameObject)
                .SetAccess<IRigidbodySwitcher>(playerMonoEntity.RigidbodySwitcher)
                .SetAccess<RigidbodySettings>(new RigidbodySettings(_playersBalance.Mass, 
                    RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ, null))
                .SetAccess<ITransform>(playerMonoEntity.Transform)
                .SetAccess<IPlayerAnimator>(new PlayerAnimator(playerMonoEntity.Animator))
                .SetAccess<IPlayerBorders>(playerMonoEntity.PlayerBorders)
                .SetupAccessible<IPlayerAnimator>(pa => pa.Setup())
                .SetupAspect<SwitchableRigidbodyAspect>(pa =>
                {
                    pa.EnablePhysicBody();
                })
                .Set(new PlayerTargetAngle { Value = rotation.eulerAngles.y })
                .Set(new PlayerSmoothAngle { Value = rotation.eulerAngles.y })
                .Set(new RotationSpeed { Value = 45f })
                .Add<PlayerFollowTransform>()
                .Add<PlayerTargetSpeed>()
                .Add<PlayerSmoothSpeed>()
                .Add<PlayerTag>();
        }
    }
}