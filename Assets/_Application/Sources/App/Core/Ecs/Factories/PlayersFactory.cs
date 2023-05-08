using System.Linq;
using Scellecs.Morpeh;
using Sirenix.Utilities;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Pathes;
using Sources.App.Data.Players;
using Sources.App.Data.Points;
using Sources.App.Services.BalanceServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.PhysicsServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.AI;
using ICollider = Sources.Utils.MorpehWrapper.DefaultComponents.Monos.ICollider;

namespace Sources.App.Core.Ecs.Factories
{
    public class PlayersFactory : Factory, IPlayersFactory
    {
        private readonly PlayersBalance _playersBalance;
        private readonly IPhysicsService _physics;

        public PlayersFactory()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        public IPlayerMonoEntity GetRandomPlayerPrefab()
        {
            PlayerType playerType = _balance.PlayersBalance.GetRandomPlayerType();
            return _assets.PlayersAssets.GetPlayerPrefab(playerType);
        }

        public Entity CreateUserInCar(IPlayerMonoEntity playerPrefab, Entity carEntity)
        {
            return CreateUser(playerPrefab, Vector3.zero, Quaternion.identity)
                .Set(new PlayerInCar { CarPlaceData = new CarPlaceData(carEntity, 0) });
        }

        public Entity CreateUser(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<UserTag>()
                .Add<UserCarInput>()
                .Add<CarSteeringAngleCoefficient>()
                .Add<UserPlayerInput>();

        public Entity CreateNpc(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation) =>
            CreatePlayer(playerPrefab, position, rotation)
                .Add<NpcTag>();

        public bool TryCreateRandomNpc(Point point, out Entity createdEntity)
        {
            IPlayerMonoEntity playerPrefab = GetRandomPlayerPrefab();

            SafeCapsuleCollider capsule = playerPrefab.PlayerBorders.SafeCapsuleCollider;

            if (CanCreateNpc(point, capsule))
            {
                createdEntity = CreateNpcOnPath(playerPrefab, point.Position, point.Rotation,
                    point.Targets.GetRandom().FirstPathLine);
                return true;
            }
            else
            {
                createdEntity = default;
                return false;
            }
        }

        private bool CanCreateNpc(Point point, SafeCapsuleCollider capsule)
        {
            return !_physics.CheckCapsule(capsule.Start + point.Position, capsule.End + point.Position,
                capsule.Radius, LayerMasks.CarsAndPlayers);
        }

        public Entity CreateNpcOnPath(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, position, rotation)
                .SetupAspect<NpcStatusAspect>(nsa => nsa.SetPath(pathLine));

            return npc;
        }

        public Entity CreateNpcInCarOnPath(IPlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine)
        {
            Entity npc = CreateNpc(playerPrefab, Vector3.zero, Quaternion.identity)
                .Set(new PlayerInCar { CarPlaceData = new CarPlaceData(carEntity, 0) })
                .SetupAspect<NpcStatusAspect>(nsa => nsa.SetPath(pathLine))
                .SetupAspect<PlayerCarPossibilityAspect>(pca =>
                    pca.EnterCar(new CarPlaceData(carEntity, 0), true));

            return npc;
        }

        public Entity CreateRandomNpcInCarOnPath(Entity car, Point point) =>
            CreateNpcInCarOnPath(GetRandomPlayerPrefab(), car, point.Targets.First().FirstPathLine);

        private Entity CreatePlayer(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation)
        {
            IPlayerMonoEntity playerMonoEntity = _poolSpawner.Spawn(playerPrefab, position, rotation);

            new CoroutineContext().RunWithDelay(1f, () =>
            {
                playerMonoEntity.RootTransform.LocalScale = Vector3.one;
            });

            return _world.CreateFromMono(playerMonoEntity)
                .AllowFixedAwaiters()
                .TrackCollisions()
                .SetRef<IEnableableGameObject>(playerMonoEntity.EnableableGameObject)
                .SetRef<NavMeshObstacle>(playerMonoEntity.NavMeshObstacle)
                .SetRef<IRigidbodySwitcher>(playerMonoEntity.RigidbodySwitcher)
                .SetRef<RigidbodySettings>(new RigidbodySettings(_playersBalance.Mass,
                    RigidbodyConstraints.FreezeRotationX |
                    RigidbodyConstraints.FreezeRotationZ, null))
                .SetRef<ITransform>(playerMonoEntity.Transform)
                .SetRef<IPlayerAnimator>(new PlayerAnimator(playerMonoEntity.Animator))
                .SetRef<IPlayerBorders>(playerMonoEntity.PlayerBorders)
                .SetRef<ICollider[]>(new ICollider[]
                    { playerMonoEntity.PlayerBorders.SafeCapsuleCollider })
                .SetupRef<ICollider[]>(cs => cs.ForEach(c => c.Layer = Layers.Player))
                .SetupRef<IPlayerAnimator>(pa => pa.SetMoveSpeed(0, true))
                .SetupAspect<SwitchableRigidbodyAspect>(pa => pa.EnableRigidbody())
                .Set(new PlayerTargetAngle { Value = rotation.eulerAngles.y })
                .Set(new PlayerSmoothAngle { Value = rotation.eulerAngles.y })
                .Set(new PlayerMoveAngle { Value = rotation.eulerAngles.y })
                .Add<RotationSpeed>()
                .Add<PlayerTargetSpeed>()
                .Add<PlayerSmoothSpeed>()
                .Add<PlayerTag>();
        }
    }
}