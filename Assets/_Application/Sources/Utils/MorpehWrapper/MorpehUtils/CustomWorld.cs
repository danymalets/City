using System;
using System.Collections.Generic;
using System.Threading;
using Scellecs.Morpeh;
using Sources.Services.FpsServices;
using Sources.Services.GameLoopServices;
using Sources.Services.TimeServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.Utils.MorpehWrapper.MorpehUtils
{
    public class CustomWorld : IService
    {
        private const float MinWorkableFps = 0;
        private const bool DebugPerformance = false;

        private readonly World _world;
        private readonly ITimeService _time;

        private readonly IFpsService _fpsService;

        private readonly List<CustomInitializer> _initializers = new();
        private readonly List<CustomUpdateSystem> _updateSystems = new();
        private readonly List<CustomUpdateSystem> _fixedSystems = new();
        private readonly List<CustomDisposer> _disposers = new();
        private readonly SystemsPerformance _systemsPerformance;
        private readonly IGameLoopService _gameLoopService;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationTokenSource _cancellationTokenSource2;

        public FilterBuilder Filter => _world.Filter;

        public float TimeScale { get; set; } = 1;
        private float PausedCoeff => IsPaused ? 0 : 1;
        public bool IsPaused { get; set; } = false;

        public Entity CreateEntity() =>
            _world.CreateEntity();

        public CustomWorld()
        {
            _time = DiContainer.Resolve<ITimeService>();
            _fpsService = DiContainer.Resolve<IFpsService>();

            _world = World.Create();
            _world.UpdateByUnity = false;

            _gameLoopService = DiContainer.Resolve<IGameLoopService>();


            _systemsPerformance = new SystemsPerformance();

#if FORCE_DEBUG
            _gameLoopService.RunEachSeconds(3f, () =>
                {
                    _systemsPerformance.LogData();
                    _systemsPerformance.Reset();
                });
#endif
        }

        public void RunSystems<TDSystem>(IEnumerable<TDSystem> systems,
            Action<TDSystem> runner, Action<TDSystem, long> performanceSender)
            where TDSystem : CustomSystem
        {
            foreach (TDSystem system in systems)
            {
                _world.Commit();
                runner(system);
            }

            _world.Commit();
        }

        public void StartGame()
        {
            RunSystems(_initializers, ConstructSystem, null);
            RunSystems(_updateSystems, ConstructSystem, null);
            RunSystems(_fixedSystems, ConstructSystem, null);
            RunSystems(_disposers, ConstructSystem, null);

            RunSystems(_initializers, s => s.Initialize(), null);

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource2 = new CancellationTokenSource();
            _gameLoopService.RunEachFrame(() =>
            {
                if (ShouldRun())
                {
                    MathUtils.Divide(TimeScale * _time.DeltaTime, _time.DeltaTime, WorldUpdate);
                }
            }, true, _cancellationTokenSource.Token);
            _gameLoopService.RunEachFixedUpdate(() =>
            {
                if (ShouldRun())
                {
                    MathUtils.Divide(TimeScale * _time.DeltaTime, _time.DeltaTime, WorldFixedUpdate);
                }
            }, _cancellationTokenSource2.Token);
        }

        private bool ShouldRun() => !IsPaused && _fpsService.FpsLastSecond >= MinWorkableFps;

        private void ConstructSystem<TDSystem>(TDSystem system)
            where TDSystem : CustomSystem
        {
            system.Setup(this);
            system.InitFilters();
        }

        private void WorldUpdate(float deltaTime)
        {
            RunSystems(_updateSystems, s => s.Update(deltaTime),
                (system, ticks) => _systemsPerformance.WriteUpdateData(system, ticks));
            _systemsPerformance.EndUpdate();
        }

        private void WorldFixedUpdate(float fixedDeltaTime)
        {
            RunSystems(_fixedSystems, s => s.Update(fixedDeltaTime),
                (system, ticks) => _systemsPerformance.WriteFixedData(system, ticks));
            _systemsPerformance.EndFixed();
        }

        public void AddInitializer<TDInitializer>() where TDInitializer : CustomInitializer, new() => 
            _initializers.Add(new TDInitializer());    
        
        public void AddDisposer<TDDisposer>() where TDDisposer : CustomDisposer, new() => 
            _disposers.Add(new TDDisposer());

        public void AddUpdateSystem<TDUpdateSystem>() where TDUpdateSystem : CustomUpdateSystem, new() => 
            _updateSystems.Add(new TDUpdateSystem());

        public void AddFixedSystem<TDFixedUpdateSystem>() where TDFixedUpdateSystem : CustomUpdateSystem, new() => 
            _fixedSystems.Add(new TDFixedUpdateSystem());

        public void AddOneFrame<TComponent>() where TComponent : struct, IComponent =>
            AddUpdateSystem<OneFrameCleanupSystem<TComponent>>();

        public void AddFixedOneFrame<TComponent>() where TComponent : struct, IComponent =>
            AddFixedSystem<OneFrameCleanupSystem<TComponent>>();

        public void FinishGame()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource2.Cancel();

            RunSystems(_disposers, s => s.Dispose(), null);

            _world.Dispose();
        }
    }
}