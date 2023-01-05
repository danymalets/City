using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Times;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DWorld
    {
        private readonly World _world;
        private readonly SystemsGroup _updateSystems;
        private readonly CoroutineContext _coroutineContext;
        private readonly ITimeService _time;

        public DWorld()
        {
            _time = DiContainer.Resolve<ITimeService>();
            
            _world = World.Create();
            _world.UpdateByUnity = false;

            _updateSystems = _world.CreateSystemsGroup();
            _world.AddSystemsGroup(0, _updateSystems);

            _coroutineContext = new CoroutineContext();
        }

        public void StartGame()
        {
            _coroutineContext.RunEachFrame(() => _updateSystems.Update(_time.DeltaTime), true);
            _coroutineContext.RunEachFixedUpdate(() => _updateSystems.FixedUpdate(_time.FixedDeltaTime));
        }

        public void AddInitializer<T>()
        {
            
        }

        public void AddUpdateSystem<TDUpdateSystem>() where TDUpdateSystem : DUpdateSystem, new()
        {
            // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
            _updateSystems.AddSystem(new DUpdateSystemProvider<TDUpdateSystem>());
        }

        public void AddFixedSystem()
        {
            
        }

        public void FinishGame()
        {
            _coroutineContext.StopAllCoroutines();
            _world.Dispose();
        }
    }
}