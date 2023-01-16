using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Systems.Fixed;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Systems.Update;
using Sources.Game.Ecs.Systems.Update.Camera;
using Sources.Game.Ecs.Systems.Update.Car;
using Sources.Game.Ecs.Systems.Update.Npc;
using Sources.Game.Ecs.Systems.Update.NpcCar;
using Sources.Game.Ecs.Systems.Update.Player;
using Sources.Game.Ecs.Systems.Update.User;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs
{
    public class EcsGame
    {
        private readonly DWorld _world;
        private readonly IDiBuilder _diBuilder;

        public EcsGame()
        {
            _world = new DWorld();

            _diBuilder = DiBuilder.Create();
            
            _diBuilder.Register<IFactory>(new Factory(_world.World));

            AddInitializers();
            AddUpdateSystems();
            AddFixedUpdateSystems();
        }

        private void AddInitializers()
        {
            _world.AddInitializer<UserInitSystem>();
            _world.AddInitializer<CameraInitSystem>();
            _world.AddInitializer<NpcInitSystem>();
            _world.AddInitializer<NpcWithCarsInitSystem>();
        }

        private void AddFixedUpdateSystems()
        {
            _world.AddFixedSystem<NpcPathChangeSystem>();
            
            _world.AddFixedSystem<NpcPathRotateSystem>();
            _world.AddFixedSystem<SmoothAngleSystem>();
            _world.AddFixedSystem<SmoothAngleApplySystem>();

            _world.AddFixedSystem<CarForwardColliderSystem>();
            
            _world.AddFixedSystem<NpcForwardColliderSystem>();
            _world.AddFixedSystem<NpcMoveSystem>();
            _world.AddFixedSystem<PlayerMoveSystem>();

            _world.AddFixedSystem<NpcCarPathChangeSystem>();
            _world.AddFixedSystem<NpcCarPathSteeringAngleSystem>();
            _world.AddFixedSystem<NpcCarMoveSystem>();
            
            _world.AddFixedSystem<NpcCarBreakPoint>();
            
            _world.AddFixedSystem<CarSmoothSteeringAngleSystem>();
            
            _world.AddFixedSystem<CarBreakApplySystem>();
            _world.AddFixedSystem<CarMotorApplySystem>();
            _world.AddFixedSystem<SteeringAngleApplySystem>();
            
            _world.AddFixedSystem<CarMaxSpeedSystem>();

            _world.AddFixedSystem<PhysicsUpdateSystem>();
        }

        private void AddUpdateSystems()
        {
            _world.AddUpdateSystem<UserTargetAngleSystem>();
            _world.AddUpdateSystem<UserMoveSystem>();
            
            _world.AddUpdateSystem<UserPlayerInputSystem>();
            _world.AddUpdateSystem<UserCarInputSystem>();
            _world.AddUpdateSystem<UserCarMoveSystem>();
            
            _world.AddUpdateSystem<CameraFollowCarRotationSystem>();
            _world.AddUpdateSystem<CameraFollowCarPositionSystem>();

            _world.AddUpdateSystem<CameraFollowPlayerRotationSystem>();
            _world.AddUpdateSystem<CameraFollowPlayerPositionSystem>();

            _world.AddUpdateSystem<ChangeSteeringAngleSystem>();
            
            _world.AddUpdateSystem<WheelGeometrySystem>();
            
            _world.AddUpdateSystem<InputScreenSwitcherSystem>();
            
            _world.AddOneFrame<ChangeSteeringAngleRequest>();
            _world.AddOneFrame<UserWantsEnterCar>();
            _world.AddOneFrame<UserWantsExitCar>();
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