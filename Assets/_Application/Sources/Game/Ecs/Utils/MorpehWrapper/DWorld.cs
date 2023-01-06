using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Times;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DWorld 
    {
       public World World { get; private set; }
        private readonly SystemsGroup _initSystemGroup;
        private readonly CoroutineContext _coroutineContext;
        private readonly ITimeService _time;

        private int _updateIndex = 0;
        private int _fixedUpdateIndex = 0;
        
        public DWorld()
        {
            _time = DiContainer.Resolve<ITimeService>();
            
            World = World.Create();
            World.UpdateByUnity = false;

            _initSystemGroup = World.CreateSystemsGroup();
            World.AddSystemsGroup(_updateIndex++, _initSystemGroup);

            _coroutineContext = new CoroutineContext();
        }

        public void StartGame()
        {

            _coroutineContext.RunEachFrame(() => World.Update(_time.DeltaTime), true);
            _coroutineContext.RunEachFixedUpdate(() => World.FixedUpdate(_time.FixedDeltaTime));
        }

        public void AddInitializer<TDInitializer>() where TDInitializer : DInitializer, new()
        {
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            _initSystemGroup.AddInitializer(new DInitializerProvider<TDInitializer>());
        }

        public void AddUpdateSystem<TDUpdateSystem>() where TDUpdateSystem : DUpdateSystem, new()
        {
            SystemsGroup systemsGroup = World.CreateSystemsGroup();
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            systemsGroup.AddSystem(new DUpdateSystemProvider<TDUpdateSystem>());
            World.AddSystemsGroup(_updateIndex++, systemsGroup);
        }

        public void AddTemp()
        {
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            _initSystemGroup.AddSystem(new A());
        }

        private class A : UpdateSystem
        {
            public override void OnAwake()
            {
                
            }

            public override void OnUpdate(float deltaTime)
            {
                Debug.Log($"updated");
            }
        }
        
        public void AddFixedSystem<TDFixedUpdateSystem>() where TDFixedUpdateSystem : DFixedUpdateSystem, new()
        {
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            _initSystemGroup.AddSystem(new DFixedUpdateSystemProvider<TDFixedUpdateSystem>());
        }

        public void AddOneFrame<TComponent>() where TComponent : struct, IComponent => 
            AddUpdateSystem<OneFrameCleanupSystem<TComponent>>();

        public void FinishGame()
        {
            _coroutineContext.StopAllCoroutines();
            World.Dispose();
        }
    }
}