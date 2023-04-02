using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Aspects;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Components.User;
using Sources.Data;
using Sources.Data.Constants;
using Sources.Data.MonoViews;
using Sources.Data.MonoViews.MonoViews;
using Sources.Monos.Components.Old.PlayerAnimators;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Services.Physics;
using Sources.Utils.DMorpeh.DefaultComponents;
using Sources.Utils.DMorpeh.DefaultComponents.Monos;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
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
            _playersBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().PlayersBalance;
        }

        public IPlayerMonoEntity GetRandomPlayerPrefab()
        {
            PlayerType playerType = _balance.PlayersBalance.GetRandomPlayerType();
            return _assets.PlayersAssets.GetPlayerPrefab(playerType);
        }

        public Entity CreateUserInCar(IPlayerMonoEntity playerPrefab, Entity carEntity)
        {
            return CreateUser(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupAccessible<EnableableGameObject>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity })
                .Set(new PlayerFollowTransform
                {
                    Position = carEntity.GetAccess<IWheelsSystem>().RootPosition,
                    Rotation = carEntity.GetAccess<ITransform>().Rotation
                });
        }

        public Entity CreateUser(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<UserTag>()
                .Add<UserCarInput>()
                .Add<UserPlayerInput>()
                .Set(new PlayerFollowTransform
                {
                    Position = position,
                    Rotation = rotation
                });

        public Entity CreateNpc(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<ForwardTrigger>()
                .Add<NpcTag>();

        public bool TryCreateRandomNpc(Point point, out Entity createdEntity)
        {
            IPlayerMonoEntity playerPrefab = GetRandomPlayerPrefab();
            
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

        public Entity CreateNpcOnPath(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, position, rotation);
            
            npc.GetAspect<NpcStatusAspect>().SetPath(pathLine);
            
            return npc;
        }

        public Entity CreateNpcInCarOnPath(IPlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, Vector3.zero, Quaternion.identity)
                .SetupAccessible<IEnableableGameObject>(g => g.Disable())
                .Set(new PlayerInCar { Car = carEntity, Place = 0 });
            
            npc.GetAspect<NpcStatusAspect>().SetPath(pathLine);

            carEntity.Get<CarPassengers>().TakePlace(0, npc);
            
            return npc;
        }

        public Entity CreateRandomNpcInCarOnPath(Entity car, Point point) => 
            CreateNpcInCarOnPath(GetRandomPlayerPrefab(), car, point.Targets.First().FirstPathLine);

        private Entity CreatePlayer(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation)
        {
            IPlayerMonoEntity playerMonoEntity = _poolSpawner.Spawn(playerPrefab, position, rotation);

            return _world.CreateFromMono(playerMonoEntity)
                .SetAccess<IEnableableGameObject>(playerMonoEntity.EnableableGameObject)
                .SetAccess<IRigidbodySwitcher>(playerMonoEntity.RigidbodySwitcher)
                .SetAccess<RigidbodySettings>(new RigidbodySettings(_playersBalance.Mass, 
                    RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ, null))
                .SetAccess<ITransform>(playerMonoEntity.Transform)
                .SetAccess<IPlayerAnimator>(new PlayerAnimator(playerMonoEntity.Animator))
                .SetAccess<IPlayerBorders>(playerMonoEntity.PlayerBorders)
                .SetupAccessible<IPlayerAnimator>(pa => pa.Setup())
                .SetupAspect<SwitchableRigidbodyAspect>(pa => pa.EnablePhysicBody())
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