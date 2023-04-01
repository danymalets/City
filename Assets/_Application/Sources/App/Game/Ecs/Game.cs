using Sources.App.DMorpeh.MorpehUtils;
using Sources.App.DMorpeh.MorpehUtils.CustomSystems;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.User;
using Sources.App.Game.Ecs.Despawners;
using Sources.App.Game.Ecs.Factories;
using Sources.App.Game.Ecs.Systems.Fixed;
using Sources.App.Game.Ecs.Systems.Init;
using Sources.App.Game.Ecs.Systems.Update;
using Sources.App.Game.Ecs.Systems.Update.Camera;
using Sources.App.Game.Ecs.Systems.Update.Car;
using Sources.App.Game.Ecs.Systems.Update.Generation;
using Sources.App.Game.Ecs.Systems.Update.Npc;
using Sources.App.Game.Ecs.Systems.Update.NpcCar;
using Sources.App.Game.Ecs.Systems.Update.Player;
using Sources.App.Game.Ecs.Systems.Update.PseudoEditor;
using Sources.App.Game.Ecs.Systems.Update.User;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs
{
    public class Game
    {
        private readonly DWorld _world;
        private readonly IDiBuilder _diBuilder;

        public Game()
        {
            _diBuilder = DiBuilder.Create();

            _world = _diBuilder.Register<DWorld>();
            
            // _diBuilder.Register(_world);
            _diBuilder.Register<IPlayersFactory>(new PlayersFactory());
            _diBuilder.Register<ICarsFactory>(new CarsFactory());
            _diBuilder.Register<IPathesFactory>(new PathesFactory());
            _diBuilder.Register<ICamerasFactory>(new CamerasFactory());
            
            _diBuilder.Register<IPlayersDespawner>(new PlayersDespawner());
            _diBuilder.Register<ICarsDespawner>(new CarsDespawner());
            _diBuilder.Register(new SimulationSettings());

            AddInitializers();
            AddUpdateSystems();
            AddFixedUpdateSystems();
        }

        private void AddInitializers()
        {
            _world.AddInitializer<PlayerDeathAnimationWarmUpSystem>();
            
            _world.AddInitializer<FogInitSystem>();
            _world.AddInitializer<PathesInitSystem>();
            _world.AddInitializer<RoadPathesGenerationSystem>();
            _world.AddInitializer<CrossroadsPathesGenerationSystem>();
            _world.AddInitializer<CrosswalksBlocksGenerationSystem>();
            _world.AddInitializer<PathesPointsFindSystem>();
            
            _world.AddInitializer<UserInitSystem>();
            _world.AddInitializer<CameraInitSystem>();
            
            _world.AddInitializer<ActiveSpawnPointsInitializeSystem>();
            
            _world.AddInitializer<NpcInitSystem>();
            _world.AddInitializer<NpcWithCarsInitSystem>();
            _world.AddInitializer<IdleCarsInitSystem>();
        }

        private void AddFixedUpdateSystems()
        {
            // physics
            _world.AddFixedSystem<PhysicsUpdateSystem>();
            
            // awaiters
            _world.AddFixedSystem<AddComponentWithDelaySystem>();

            // follow transform
            _world.AddFixedSystem<PlayerFollowTransformUpdateSystem>();
            _world.AddFixedSystem<PlayerWithCarFollowTransformUpdateSystem>();

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
            _world.AddFixedSystem<ActiveSpawnPointsUpdateSystem>();
            
            _world.AddFixedSystem<InactiveNpcDespawnSystem>();
            _world.AddFixedSystem<InactiveCarsDespawnSystem>();
            
            _world.AddFixedSystem<HorizonCarsSpawnSystem>();
            _world.AddFixedSystem<HorizonNpcSpawnSystem>();
            
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
            _world.AddFixedSystem<NpcMoveSystem>();
            
            // car
            _world.AddFixedSystem<NpcCarPathSteeringAngleSystem>();
            _world.AddFixedSystem<NpcCarMoveSystem>();
            
            // paths
            
            _world.AddFixedSystem<NpcCarBreakOrMoveChoiceSystem>();
            _world.AddFixedSystem<NpcBreakOrMoveChoiceSystem>();

            _world.AddFixedSystem<NpcCarBreakSystem>();
            _world.AddFixedSystem<NpcBreakSystem>();
            
            // npc apply
            _world.AddFixedSystem<PlayerSmoothSpeedSystem>();
            _world.AddFixedSystem<PlayerApplySpeedSystem>();

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
            _world.AddUpdateSystem<UserTargetAngleAndSpeedSystem>();
            _world.AddUpdateSystem<NpcSpeedSystem>();
            
            _world.AddUpdateSystem<UserMoveSystem>();
            
            _world.AddUpdateSystem<UserPlayerInputSystem>();
            _world.AddUpdateSystem<UserCarInputSystem>();
            _world.AddUpdateSystem<UserCarMoveSystem>();
            
            _world.AddUpdateSystem<PlayerFollowTransformUpdateSystem>();
            _world.AddUpdateSystem<PlayerWithCarFollowTransformUpdateSystem>();
            _world.AddUpdateSystem<UserFogUpdateSystem>();

            _world.AddUpdateSystem<ChangeSteeringAngleSystem>();
            
            _world.AddUpdateSystem<WheelGeometrySystem>();

            _world.AddUpdateSystem<InputScreenSwitcherSystem>();
            
            _world.AddUpdateSystem<CameraXAngleApplySystem>();
            _world.AddUpdateSystem<CameraFieldOfViewApplySystem>();
            
            _world.AddUpdateSystem<CameraTargetDeltasSystem>();
            _world.AddUpdateSystem<CameraSmoothDeltasSystem>();
            
            _world.AddUpdateSystem<CameraTargetXAngleSystem>();
            _world.AddUpdateSystem<CameraSmoothXAngleSystem>();
            
            _world.AddUpdateSystem<CameraFollowXPositionSystem>();

            _world.AddUpdateSystem<CameraFollowPlayerRotationSystem>();
            _world.AddUpdateSystem<CameraFollowPlayerPositionSystem>();

#if UNITY_EDITOR
            _world.AddUpdateSystem<PathesGizmosSystem>();
#endif

            _world.AddOneFrame<ChangeSteeringAngleRequest>();
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