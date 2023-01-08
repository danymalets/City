using Sources.Game.Ecs.Components.Car;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Systems.Fixed;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Systems.Update;
using Sources.Game.Ecs.Systems.Update.Camera;
using Sources.Game.Ecs.Systems.Update.Car;
using Sources.Game.Ecs.Systems.Update.Npc;
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
            _world.AddInitializer<PathSystemInitSystem>();
            _world.AddInitializer<NpcWithCarsInitSystem>();
        }

        private void AddFixedUpdateSystems()
        {
            _world.AddFixedSystem<NpcCarPathChangeSystem>();
            _world.AddFixedSystem<NpcCarPathMoveSystem>();
            
            _world.AddFixedSystem<CarSmoothSteeringAngleSystem>();
            
            _world.AddFixedSystem<CarBreakApplySystem>();
            _world.AddFixedSystem<CarMotorApplySystem>();
            _world.AddFixedSystem<SteeringAngleApplySystem>();
            
            _world.AddFixedSystem<CarMaxSpeedSystem>();

            _world.AddFixedSystem<PhysicsUpdateSystem>();
        }

        private void AddUpdateSystems()
        {
            _world.AddUpdateSystem<UserInputSystem>();
            _world.AddUpdateSystem<PlayerCarMoveSystem>();
            
            _world.AddUpdateSystem<CameraRotationSystem>();
            _world.AddUpdateSystem<CameraPositionSystem>();
            
            _world.AddUpdateSystem<ChangeSteeringAngleSystem>();
            
            _world.AddUpdateSystem<WheelGeometrySystem>();
            
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