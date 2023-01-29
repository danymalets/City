using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Systems.Fixed;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Systems.Update;
using Sources.Game.Ecs.Systems.Update.Camera;
using Sources.Game.Ecs.Systems.Update.Car;
using Sources.Game.Ecs.Systems.Update.Generation;
using Sources.Game.Ecs.Systems.Update.Npc;
using Sources.Game.Ecs.Systems.Update.NpcCar;
using Sources.Game.Ecs.Systems.Update.Player;
using Sources.Game.Ecs.Systems.Update.PseudoEditor;
using Sources.Game.Ecs.Systems.Update.User;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs
{
    public class Game
    {
        private readonly DWorld _world;
        private readonly IDiBuilder _diBuilder;

        public Game()
        {
            _world = new DWorld();

            _diBuilder = DiBuilder.Create();
            
            _diBuilder.Register<IFactory>(new Factory(_world.World));
            _diBuilder.Register<IDespawner>(new Despawner());

            AddInitializers();
            AddUpdateSystems();
            AddFixedUpdateSystems();
        }

        private void AddInitializers()
        {
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
        }

        private void AddFixedUpdateSystems()
        {
            _world.AddFixedSystem<PlayerCarExitSystem>();
            _world.AddFixedSystem<PlayerCarEnterSystem>();
            
            // gen
            _world.AddFixedSystem<ActiveSpawnPointsUpdateSystem>();
            
            _world.AddFixedSystem<InactiveNpcDespawnSystem>();
            _world.AddFixedSystem<InactiveCarsDespawnSystem>();
            
            _world.AddFixedSystem<HorizonCarsSpawnSystem>();
            _world.AddFixedSystem<HorizonNpcSpawnSystem>();

            // npc
            
            _world.AddFixedSystem<NpcPathEndCheckSystem>();
            _world.AddFixedSystem<NpcCarPathEndCheckSystem>();

            _world.AddFixedSystem<NpcPathLineChangeSystem>();
            _world.AddFixedSystem<NpcPathChoiceSystem>();
            
            _world.AddFixedSystem<NpcPathRotateSystem>();
            _world.AddFixedSystem<SmoothAngleSystem>();
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

            _world.AddFixedSystem<CarBreakApplySystem>();
            _world.AddFixedSystem<CarMotorApplySystem>();
            _world.AddFixedSystem<SteeringAngleApplySystem>();
            

            // physics
            _world.AddFixedSystem<PhysicsUpdateSystem>();
            
            _world.AddFixedOneFrame<NpcPointReachedEvent>();
            _world.AddFixedOneFrame<NpcBreakRequest>();
            _world.AddFixedOneFrame<NpcCarBreakRequest>();
            _world.AddFixedOneFrame<PlayerWantsExitCar>();
            _world.AddFixedOneFrame<PlayerWantsEnterCar>();
        }

        private void AddUpdateSystems()
        {
            _world.AddUpdateSystem<UserTargetAngleSystem>();
            _world.AddUpdateSystem<UserMoveSystem>();
            
            _world.AddUpdateSystem<UserPlayerInputSystem>();
            _world.AddUpdateSystem<UserCarInputSystem>();
            _world.AddUpdateSystem<UserCarMoveSystem>();
            
            _world.AddUpdateSystem<UserFollowTransformUpdateSystem>();
            _world.AddUpdateSystem<UserWithCarFollowTransformUpdateSystem>();
            _world.AddUpdateSystem<UserFogUpdateSystem>();

            _world.AddUpdateSystem<ChangeSteeringAngleSystem>();
            
            _world.AddUpdateSystem<WheelGeometrySystem>();

            _world.AddUpdateSystem<InputScreenSwitcherSystem>();
            
            _world.AddUpdateSystem<CameraTiltAngleApplySystem>();
            _world.AddUpdateSystem<CameraFieldOfViewApplySystem>();
            
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