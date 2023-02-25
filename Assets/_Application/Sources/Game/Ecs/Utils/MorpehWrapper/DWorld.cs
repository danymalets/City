using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Times;
using Sources.Utilities;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class DWorld : IService
    {
        private const bool DebugPerformance = true;
        
        public World World { get; private set; }
        private readonly CoroutineContext _coroutineContext;
        private readonly ITimeService _time;

        private int _updateIndex = 0;
        private readonly IFpsService _fpsService;

        private readonly List<DInitializer> _initializers = new();
        private readonly List<DUpdateSystem> _updateSystems = new();
        private readonly List<DUpdateSystem> _fixedSystems = new();
        private readonly SystemsPerformance _systemsPerformance;

        public DWorld()
        {
            _time = DiContainer.Resolve<ITimeService>();
            _fpsService = DiContainer.Resolve<IFpsService>();
            
            World = World.Create();
            World.UpdateByUnity = false;

            _coroutineContext = new CoroutineContext();

            _systemsPerformance = new SystemsPerformance();

            if (DebugPerformance)
            {
                _coroutineContext.RunEachSeconds(3f, () =>
                {
                    _systemsPerformance.LogData();
                    _systemsPerformance.Reset();
                });
            }
        }

        public void StartGame()
        {
            foreach (DInitializer initializer in _initializers)
            {
                initializer.Setup(World);
                initializer.Construct();
                initializer.Initialize();
                World.Commit();

            }
            
            foreach (DUpdateSystem updateSystem in _updateSystems)
            {
                updateSystem.Setup(World);
                updateSystem.Construct();
                updateSystem.Initialize();
                World.Commit();

            }
            
            foreach (DUpdateSystem fixedSystem in _fixedSystems)
            {
                fixedSystem.Setup(World);
                fixedSystem.Construct();
                fixedSystem.Initialize();
                World.Commit();
            }
            
            _coroutineContext.RunEachFrame(() =>
            {
                if (_fpsService.FpsLastSecond >= 20)
                    WorldUpdate(_time.DeltaTime);
            }, true);
            _coroutineContext.RunEachFixedUpdate(() =>
            {
                if (_fpsService.FpsLastSecond >= 20)
                    WorldFixedUpdate(_time.FixedDeltaTime);
            });
        }

        private void WorldUpdate(float deltaTime)
        {
            foreach (DUpdateSystem updateSystem in _updateSystems)
            {
                if (DebugPerformance)
                {
                    long ticks = DPerformance.Execute(() =>
                    {
                        updateSystem.Update(deltaTime);
                    });
                    _systemsPerformance.WriteUpdateData(updateSystem, ticks);
                }
                else
                {
                    updateSystem.Update(deltaTime);
                }

                World.Commit();
            }
        }

        private void WorldFixedUpdate(float fixedDeltaTime)
        {
            foreach (DUpdateSystem fixedSystem in _fixedSystems)
            {
                if (DebugPerformance)
                {
                    long ticks = DPerformance.Execute(() =>
                    {
                        fixedSystem.Update(fixedDeltaTime);
                    });
                    _systemsPerformance.WriteFixedData(fixedSystem, ticks);
                }
                else
                {
                    fixedSystem.Update(fixedDeltaTime);
                }
                World.Commit();
            }
        }

        public void AddInitializer<TDInitializer>() where TDInitializer : DInitializer, new()
        {
            _initializers.Add(new TDInitializer());
        }

        public void AddUpdateSystem<TDUpdateSystem>() where TDUpdateSystem : DUpdateSystem, new()
        {
            _updateSystems.Add(new TDUpdateSystem());
        }

        public void AddFixedSystem<TDFixedUpdateSystem>() where TDFixedUpdateSystem : DUpdateSystem, new()
        {
            _fixedSystems.Add(new TDFixedUpdateSystem());
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