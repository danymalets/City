using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Despawners;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Core.Ecs.Systems.Init;
using Sources.App.Core.Ecs.Systems.Update.Camera;
using Sources.App.Core.Ecs.Systems.Update.Car;
using Sources.App.Core.Ecs.Systems.Update.Common;
using Sources.App.Core.Ecs.Systems.Update.Generation;
using Sources.App.Core.Ecs.Systems.Update.Npc;
using Sources.App.Core.Ecs.Systems.Update.NpcCar;
using Sources.App.Core.Ecs.Systems.Update.NpcPathes;
using Sources.App.Core.Ecs.Systems.Update.Player;
using Sources.App.Core.Ecs.Systems.Update.Player.NavToCar;
using Sources.App.Core.Ecs.Systems.Update.Props;
using Sources.App.Core.Ecs.Systems.Update.PseudoEditor;
using Sources.App.Core.Ecs.Systems.Update.User;
using Sources.App.Core.Services;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems;

namespace Sources.App.Core.Ecs
{
    public class Game
    {
        private readonly DWorld _world;
        private readonly IDiBuilder _diBuilder;

        public Game()
        {
            _diBuilder = DiBuilder.Create();

            _world = _diBuilder.Register<DWorld>();
            
            RegisterGameServices();

            AddInitializers();
            AddUpdateSystems();
            AddFixedUpdateSystems();
        }

        private void RegisterGameServices()
        {
            _diBuilder.Register<PlayersFactory, IPlayersFactory>();
            _diBuilder.Register<CarsFactory, ICarsFactory>();
            _diBuilder.Register<PathesFactory, IPathesFactory>();
            _diBuilder.Register<CamerasFactory, ICamerasFactory>();
            _diBuilder.Register<PropsFactory, IPropsFactory>();
            _diBuilder.Register<SimulationAreasFactory, ISimulationAreasFactory>();
            
            _diBuilder.Register<PlayersDespawner, IPlayersDespawner>();
            _diBuilder.Register<CarsDespawner, ICarsDespawner>();
            _diBuilder.Register<SimulationSettings, ISimulationSettings>();
            _diBuilder.Register<NavigationService, INavigationService>();
        }

        private void AddInitializers()
        {
            _world.AddInitializer<WorldStatusInitSystem>();
            
            _world.AddInitializer<PropsInitSystem>();
            
            _world.AddInitializer<PlayerDeathAnimationWarmUpSystem>();

            _world.AddInitializer<SimulationAreasInitSystem>();

            _world.AddInitializer<FogInitSystem>();
            _world.AddInitializer<PathesInitSystem>();
            _world.AddInitializer<RoadPathesGenerationSystem>();
            _world.AddInitializer<CrossroadsPathesGenerationSystem>();
            _world.AddInitializer<CrosswalksBlocksGenerationSystem>();
            _world.AddInitializer<PathesPointsFindSystem>();
            
            _world.AddInitializer<UserInitSystem>();
            _world.AddInitializer<CameraInitSystem>();
            
            _world.AddInitializer<SimulationInitSystem>();
            
            _world.AddInitializer<IdleCarsInitSystem>();
        }

        private void AddFixedUpdateSystems()
        {
            // awaiters
            _world.AddFixedSystem<FixedAwaitersProcessSystem>();
            
            // physics
            _world.AddFixedSystem<PhysicsUpdateSystem>();

            //death
            _world.AddFixedSystem<PlayerFallCheckSystem>();
            _world.AddFixedSystem<PlayerDeathHandlerSystem>();
            _world.AddFixedSystem<FallAnimationHandlerSystem>();
            _world.AddFixedSystem<DespawnRequestHandlerSystem>();

            //car enter
            _world.AddFixedSystem<UserNearbyCarsCheckSystem>();
            
            _world.AddFixedSystem<PlayerWantsEnterCarHandlerSystem>();
            
            _world.AddFixedSystem<PlayerNavPathRotationSpeedSystem>();
            _world.AddFixedSystem<PlayerNavigationMoveSystem>();
            
            _world.AddFixedSystem<PlayerNavigationFailedHandlerSystem>();
            _world.AddFixedSystem<PlayerNavigationCompletedHandlerSystem>();
            _world.AddFixedSystem<PlayerNavToCarFailedReceiverSystem>();
            _world.AddFixedSystem<PlayerNavToCarCheckCompleteSystem>();
            _world.AddFixedSystem<PlayerNavToCarCompletedHandlerSystem>();
            
            _world.AddFixedSystem<PlayerEnterCarHandlerSystem>();
            
            //car exit
            _world.AddFixedSystem<PlayerCarStartExitSystem>();
            _world.AddFixedSystem<PlayerCarFullyExitSystem>();

            // generation
            _world.AddFixedSystem<CameraTargetDeltasSystem>();
            _world.AddFixedSystem<SimulationCameraUpdateSystem>();
            _world.AddFixedSystem<SimulationAreaUpdateSystem>();
            
            _world.AddFixedSystem<ActiveSpawnPointsUpdateSystem>();
            
            _world.AddFixedSystem<InactiveNpcDespawnSystem>();
            _world.AddFixedSystem<InactiveCarsDespawnSystem>();
            
            _world.AddFixedSystem<CarsSpawnSystem>();
            _world.AddFixedSystem<NpcsSpawnSystem>();
            
            // npc
            _world.AddFixedSystem<NpcPathEndCheckSystem>();
            _world.AddFixedSystem<NpcCarPathEndCheckSystem>();

            _world.AddFixedSystem<NpcPathLineChangeSystem>();
            _world.AddFixedSystem<NpcPathChoiceSystem>();
            
            _world.AddFixedSystem<NpcPathRotateSystem>();
            _world.AddFixedSystem<PlayerSmoothAngleSystem>();
            _world.AddFixedSystem<SmoothAngleApplySystem>();
            
            _world.AddFixedSystem<NpcOnPathForwardColliderRequestSystem>();
            _world.AddFixedSystem<PlayerOnNavPathForwardColliderRequestSystem>();
            
            _world.AddFixedSystem<PlayerForwardColliderCalculateSystem>();
            _world.AddFixedSystem<PlayerCheckForwardTriggerSystem>();

            // idle car
            _world.AddFixedSystem<IdleCarEnableRigidbodySystem>();
            _world.AddFixedSystem<IdleCarDisableRigidbodySystem>();

            // car
            _world.AddFixedSystem<NpcCarPathSteeringAngleSystem>();
            _world.AddFixedSystem<CarForwardColliderCalculateSystem>();
            _world.AddFixedSystem<NpcCarCheckForwardTriggerSystem>();
            
            // pathes
            _world.AddFixedSystem<NpcCarBreakOrMoveChoiceSystem>();
            _world.AddFixedSystem<NpcBreakOrMoveChoiceSystem>();

            _world.AddFixedSystem<NpcCarBreakSystem>();
            _world.AddFixedSystem<NpcOnPathMoveSystem>();
            
            // npc apply
            _world.AddFixedSystem<PlayerSmoothSpeedSystem>();
            _world.AddFixedSystem<PlayerMoveAngleCalculateSystem>();
            _world.AddFixedSystem<PlayerApplySpeedSystem>();
            _world.AddFixedSystem<PlayerAnimatorSpeedSystem>();

            // car apply
            _world.AddFixedSystem<CarSmoothSteeringAngleSystem>();
            
            _world.AddFixedSystem<CarMaxSpeedSystem>();
            _world.AddFixedSystem<CarBreakResetSystem>();

            _world.AddFixedSystem<CarBreakApplySystem>();
            _world.AddFixedSystem<CarMotorApplySystem>();
            _world.AddFixedSystem<SteeringAngleApplySystem>();
            
            //props
            _world.AddFixedSystem<PropsRigidbodyEnableSystem>();
            _world.AddFixedSystem<PropsRigidbodyDisableSystem>();
            _world.AddFixedSystem<PropsFallSystem>();
            _world.AddFixedSystem<PropsFallenCheckSystemSystem>();

            // set layer
            _world.AddFixedSystem<SetFallenLayerRequestHandlerSystem>();

            // clear collisions
            _world.AddFixedSystem<CollisionsClearSystem>();

            // on frames
            _world.AddFixedOneFrame<NpcPointReachedEvent>();
            _world.AddFixedOneFrame<OnNavFailedEvent>();
            _world.AddFixedOneFrame<OnNavToCarFailedEvent>();
            _world.AddFixedOneFrame<NavPathCompletedEvent>();
            _world.AddFixedOneFrame<NavToCarCompletedEvent>();
            _world.AddFixedOneFrame<PlayerEnterCarEvent>();
            _world.AddFixedOneFrame<PathBlockerRequest>();
            _world.AddFixedOneFrame<ForwardBlockerRequest>();
            _world.AddFixedOneFrame<NpcCarBreakRequest>();
            _world.AddFixedOneFrame<PlayerStartExitCarRequest>();
            _world.AddFixedOneFrame<PlayerWantsEnterCarEvent>();
            _world.AddFixedOneFrame<PlayerFullyExitCarRequest>();
            _world.AddFixedOneFrame<DeadRequest>();
            _world.AddFixedOneFrame<FallAnimationRequest>();
            _world.AddFixedOneFrame<SetLayerRequest>();
            _world.AddFixedOneFrame<DespawnRequest>();
            _world.AddFixedOneFrame<CheckForwardTriggerRequest>();
        }

        private void AddUpdateSystems()
        {
            _world.AddUpdateSystem<UpdateAwaitersProcessSystem>();

            // user
            _world.AddUpdateSystem<NpcSpeedSystem>();
            
            _world.AddUpdateSystem<UserWithoutCarInputReceiverSystem>();
            _world.AddUpdateSystem<UserWithCarInputReceiverSystem>();
            
            _world.AddUpdateSystem<UserTargetMoveSpeedByInputSystem>();

            _world.AddUpdateSystem<UserTargetAngleSystem>();
            _world.AddUpdateSystem<UserRotationSpeedSystem>();
            _world.AddUpdateSystem<UserCarInputHandlerSystem>();
            
            // wtf
            _world.AddUpdateSystem<ChangeSteeringAngleSystem>();

            // fog
            _world.AddUpdateSystem<UserFogUpdateSystem>();
            
            // wheels geometry
            _world.AddUpdateSystem<WheelGeometrySystem>();

            // ui
            _world.AddUpdateSystem<InputScreenSwitcherSystem>();
            
            // camera
            _world.AddUpdateSystem<CameraXAngleApplySystem>();
            _world.AddUpdateSystem<CameraFieldOfViewApplySystem>();
            
            _world.AddUpdateSystem<CameraTargetDeltasSystem>();
            _world.AddUpdateSystem<CameraSmoothDeltasSystem>();
            
            _world.AddUpdateSystem<CameraTargetXAngleSystem>();
            _world.AddUpdateSystem<CameraSmoothXAngleSystem>();
            
            _world.AddUpdateSystem<CameraFollowXPositionSystem>();

            _world.AddUpdateSystem<CameraFollowPlayerRotationSystem>();
            _world.AddUpdateSystem<CameraFollowPlayerPositionSystem>();
            
            // map camera
            _world.AddUpdateSystem<MapCameraUpdateSystem>();
            
            // player in car position
            _world.AddUpdateSystem<PlayerInCarPositionUpdaterSystem>();

#if UNITY_EDITOR
            _world.AddUpdateSystem<PathesGizmosSystem>();
            _world.AddUpdateSystem<NpcForwardColliderGizmosSystem>();
            _world.AddUpdateSystem<CarForwardColliderGizmosSystem>();
#endif
        }

        public void StartGame() => 
            _world.StartGame();

        public void FinishGame()
        {
            _world.FinishGame();
            _diBuilder.Dispose();
        }
    }
}