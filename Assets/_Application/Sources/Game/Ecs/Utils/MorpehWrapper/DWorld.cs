using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Times;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DWorld : IService
    {
        public World World { get; private set; }
        private readonly SystemsGroup _initSystemGroup;
        private readonly CoroutineContext _coroutineContext;
        private readonly ITimeService _time;

        private int _updateIndex = 0;
        private readonly IFpsService _fpsService;

        public DWorld()
        {
            _time = DiContainer.Resolve<ITimeService>();
            _fpsService = DiContainer.Resolve<IFpsService>();
            
            World = World.Create();
            World.UpdateByUnity = false;

            _initSystemGroup = World.CreateSystemsGroup();
            World.AddSystemsGroup(_updateIndex++, _initSystemGroup);

            _coroutineContext = new CoroutineContext();
        }

        public void StartGame()
        {
            _coroutineContext.RunEachFrame(() =>
            {
                if (_fpsService.FpsLastSecond >= 20)
                    World.Update(_time.DeltaTime);
            }, true);
            _coroutineContext.RunEachFixedUpdate(() =>
            {
                if (_fpsService.FpsLastSecond >= 20)
                    World.FixedUpdate(_time.FixedDeltaTime);
            });
        }

        public void AddInitializer<TDInitializer>() where TDInitializer : DInitializer, new()
        {
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            _initSystemGroup.AddInitializer(new DInitializerProvider<TDInitializer>());
        }

        public void AddUpdateSystem<TDUpdateSystem>(int order = -1) where TDUpdateSystem : DUpdateSystem, new()
        {
            SystemsGroup systemsGroup = World.CreateSystemsGroup();
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            systemsGroup.AddSystem(new DUpdateSystemProvider<TDUpdateSystem>());
            World.AddSystemsGroup(order != -1 ? order : _updateIndex++, systemsGroup);
        }

        public void AddFixedSystem<TDFixedUpdateSystem>(int order = -1) where TDFixedUpdateSystem : DUpdateSystem, new()
        {
            SystemsGroup systemsGroup = World.CreateSystemsGroup();
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            systemsGroup.AddSystem(new DFixedUpdateSystemProvider<TDFixedUpdateSystem>());
            World.AddSystemsGroup(order != -1 ? order : _updateIndex++, systemsGroup);
        }

        public void AddOneFrame<TComponent>() where TComponent : struct, IComponent => 
            AddUpdateSystem<OneFrameCleanupSystem<TComponent>>();

        public void FinishGame()
        {
            _coroutineContext.StopAllCoroutines();
            World.Dispose();
        }

        public void AddFixedOneFrame<TComponent>() where TComponent : struct, IComponent => 
            AddFixedSystem<OneFrameCleanupSystem<TComponent>>();
    }
}