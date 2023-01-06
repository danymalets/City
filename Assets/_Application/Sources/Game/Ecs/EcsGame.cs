using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Systems;
using Sources.Game.Ecs.Systems.Fixed;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Systems.Update;
using Sources.Game.Ecs.Systems.Update.Camera;
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

            _diBuilder.Register<ICarFactory>(new CarFactory(_world.World));
            _diBuilder.Register<IUserFactory>(new UserFactory(_world.World));
            _diBuilder.Register<ICameraFactory>(new CameraFactory(_world.World));

            AddInitializers();
            AddUpdateSystems();
            AddOneFrames();
            AddFixedUpdateSystems();
        }

        private void AddInitializers()
        {
            _world.AddInitializer<UserInitSystem>();
            _world.AddInitializer<CameraInitSystem>();
        }

        private void AddFixedUpdateSystems()
        {
            _world.AddFixedSystem<PhysicsUpdateSystem>();
        }

        private void AddUpdateSystems()
        {
            _world.AddUpdateSystem<UserInputSystem>();
            _world.AddUpdateSystem<PlayerCarMoveSystem>();

            _world.AddUpdateSystem<CameraRotationSystem>();
            _world.AddUpdateSystem<CameraPositionSystem>();
        }

        private void AddOneFrames()
        {
            // _world.AddOneFrame<>();
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