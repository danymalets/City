using Leopotam.Ecs;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Systems.Fixed;
using Sources.Game.Ecs.Systems.Init;
using Sources.Game.Ecs.Systems.Update;
using Sources.Game.Ecs.Systems.Update.Camera;
using Sources.Game.Ecs.Systems.Update.View;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;

#if UNITY_EDITOR
using Leopotam.Ecs.UnityIntegration;
#endif

namespace Sources.Game.Ecs
{
    public class EcsGame
    {
        private readonly CoroutineContext _coroutineContext;
        
        private readonly EcsSystems _initSystems;
        private readonly EcsSystems _updateSystems;
        private readonly EcsSystems _fixedSystems;
        private readonly EcsWorld _world;

        public EcsGame()
        {
            _coroutineContext = new CoroutineContext();
            
            _world = new EcsWorld ();

            DiContainer.Register<IUserFactory>(new UserFactory(_world));
            
#if UNITY_EDITOR
            EcsWorldObserver.Create (_world);
#endif

            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);
            
            SetupSystems();
            
            Inject(new CarFactory(_world));
            Inject(new UserFactory(_world));
            Inject(new CameraFactory(_world));

#if UNITY_EDITOR
            //EcsSystemsObserver.Create (_initSystems);
            EcsSystemsObserver.Create (_updateSystems);
            //EcsSystemsObserver.Create (_fixedSystems);
#endif
        }

        private void SetupSystems()
        {
            SetupInitSystems();
            SetupUpdateSystems();
            SetupFixedSystems();
        }

        private void SetupInitSystems()
        {
            _initSystems.Add(new UserInitSystem());
            _initSystems.Add(new CameraInitSystem());
        }

        private void SetupUpdateSystems()
        {
            _updateSystems.Add(new UserInputSystem());
            _updateSystems.Add(new PlayerCarMoveSystem());
            
            _updateSystems.Add(new CameraRotationSystem());
            _updateSystems.Add(new CameraPositionSystem());
            
            _updateSystems.Add(new ApplyPositionSystem());
            _updateSystems.Add(new ApplyRotationSystem());
        }

        private void SetupFixedSystems()
        {
            _fixedSystems.Add(new PhysicsUpdateSystem());
            _fixedSystems.Add(new ApplyPhysicalPositionSystem());
            _fixedSystems.Add(new ApplyPhysicalRotationSystem());
        }

        public void StartGame()
        {
            _initSystems.Init();
            _fixedSystems.Init();
            _updateSystems.Init();

            _coroutineContext.RunEachFrame(_updateSystems.Run, true);
            _coroutineContext.RunEachFixedUpdate(_fixedSystems.Run);
        }

        public void FinishGame()
        {
            _coroutineContext.StopAllCoroutines();

            _initSystems.Destroy();
            _fixedSystems.Destroy();
            _updateSystems.Destroy();
            
            _world.Destroy();
        }

        private void Inject(object obj)
        {
            _initSystems.Inject(obj);
            _updateSystems.Inject(obj);
            _fixedSystems.Inject(obj);
        }
    }
}