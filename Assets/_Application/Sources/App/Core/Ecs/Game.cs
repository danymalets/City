using Sources.App.Core.Ecs.Components.Car;
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
using Sources.App.Core.Ecs.Systems.Update.PseudoEditor;
using Sources.App.Core.Ecs.Systems.Update.User;
using Sources.App.Core.Services;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
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
            _diBuilder.Register<IPlayersFactory>(new PlayersFactory());
            _diBuilder.Register<ICarsFactory>(new CarsFactory());
            _diBuilder.Register<IPathesFactory>(new PathesFactory());
            _diBuilder.Register<ICamerasFactory>(new CamerasFactory());
            _diBuilder.Register<ISimulationAreasFactory>(new SimulationAreasFactory());

            _diBuilder.Register<IPlayersDespawner>(new PlayersDespawner());
            _diBuilder.Register<ICarsDespawner>(new CarsDespawner());
            _diBuilder.Register<ISimulationSettings>(new SimulationSettings());
        }

        private void AddInitializers()
        {
            _world.AddInitializer<WorldStatusInitSystem>();
            
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
            _world.AddFixedSystem<ComponentProcessSystem>();
            
            // physics
            _world.AddFixedSystem<PhysicsUpdateSystem>();

            //death
            _world.AddFixedSystem<PlayerFallCheckSystem>();
            _world.AddFixedSystem<PlayerDeathHandlerSystem>();
            _world.AddFixedSystem<FallAnimationHandlerSystem>();
            _world.AddFixedSystem<MakeKinematicHandlerSystem>();
            _world.AddFixedSystem<DisableCollidersRequestHandlerSystem>();
            _world.AddFixedSystem<DespawnRequestHandlerSystem>();

            //car exit
            _world.AddFixedSystem<PlayerCarExitSystem>();
            _world.AddFixedSystem<PlayerCarEnterSystem>();
            
            // gen
            _world.AddFixedSystem<CameraTargetDeltasSystem>();
            _world.AddFixedSystem<SimulationCameraUpdateSystem>();
            _world.AddFixedSystem<SimulationAreaUpdateSystem>();
            
            _world.AddFixedSystem<ActiveSpawnPointsUpdateSystem>();
            
            _world.AddFixedSystem<InactiveNpcDespawnSystem>();
            _world.AddFixedSystem<InactiveCarsDespawnSystem>();
            
            _world.AddFixedSystem<CarsSpawnSystem>();
            _world.AddFixedSystem<NpcsSpawnSystem>();
            
            _world.AddFixedSystem<IdleCarsSpawnSystem>();

            // npc
            _world.AddFixedSystem<NpcPathEndCheckSystem>();
            _world.AddFixedSystem<NpcCarPathEndCheckSystem>();

            _world.AddFixedSystem<NpcPathLineChangeSystem>();
            _world.AddFixedSystem<NpcPathChoiceSystem>();
            
            _world.AddFixedSystem<NpcPathRotateSystem>();
            _world.AddFixedSystem<PlayerSmoothAngleSystem>();
            _world.AddFixedSystem<SmoothAngleApplySystem>();

            _world.AddFixedSystem<CarForwardColliderSystem>();
            
            _world.AddFixedSystem<NpcForwardColliderSystem>();
            _world.AddFixedSystem<NpcTargetSpeedSystem>();
            
            // idle car
            _world.AddFixedSystem<IdleCarEnableRigidbodySystem>();
            _world.AddFixedSystem<IdleCarDisableRigidbodySystem>();

            // car
            _world.AddFixedSystem<NpcCarPathSteeringAngleSystem>();
            _world.AddFixedSystem<NpcCarMoveSystem>();
            
            // pathes
            _world.AddFixedSystem<NpcCarBreakOrMoveChoiceSystem>();
            _world.AddFixedSystem<NpcBreakOrMoveChoiceSystem>();

            _world.AddFixedSystem<NpcCarBreakSystem>();
            _world.AddFixedSystem<NpcBreakSystem>();
            
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

            _world.AddFixedOneFrame<NpcPointReachedEvent>();
            _world.AddFixedOneFrame<NpcBreakRequest>();
            _world.AddFixedOneFrame<NpcCarBreakRequest>();
            _world.AddFixedOneFrame<PlayerWantsExitCar>();
            _world.AddFixedOneFrame<PlayerWantsEnterCar>();
            _world.AddFixedOneFrame<DeadRequest>();
            _world.AddFixedOneFrame<FallAnimationRequest>();
            _world.AddFixedOneFrame<DisableCollidersRequest>();
            _world.AddFixedOneFrame<MakeKinematicRequest>();
            _world.AddFixedOneFrame<DespawnRequest>();
            _world.AddFixedOneFrame<Collisions>();
        }

        private void AddUpdateSystems()
        {
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
            
            // geometry
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

#if UNITY_EDITOR
            _world.AddUpdateSystem<PathesGizmosSystem>();
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