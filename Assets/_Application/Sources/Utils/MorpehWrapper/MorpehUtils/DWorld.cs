using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.FpsServices;
using Sources.Services.TimeServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Sources.Utils.MorpehWrapper.MorpehUtils
{
    public class DWorld : IService
    {
        private const float MinWorkableFps = 0;
        private const bool DebugPerformance = false;

        private readonly World _world;
        private readonly CoroutineContext _coroutineContext;
        private readonly ITimeService _time;

        private readonly IFpsService _fpsService;

        private readonly List<DInitializer> _initializers = new();
        private readonly List<DUpdateSystem> _updateSystems = new();
        private readonly List<DUpdateSystem> _fixedSystems = new();
        private readonly List<DDisposer> _disposers = new();
        private readonly SystemsPerformance _systemsPerformance;
        
        public FilterBuilder Filter => _world.Filter;

        public float TimeScale { get; set; } = 1;

        public Entity CreateEntity() =>
            _world.CreateEntity();

        public DWorld()
        {
            _time = DiContainer.Resolve<ITimeService>();
            _fpsService = DiContainer.Resolve<IFpsService>();

            _world = World.Create();
            _world.UpdateByUnity = false;

            _coroutineContext = new CoroutineContext();

            _systemsPerformance = new SystemsPerformance();

#if FORCE_DEBUG
                _coroutineContext.RunEachSeconds(3f, () =>
                {
                    _systemsPerformance.LogData();
                    _systemsPerformance.Reset();
                });
#endif
        }

        public void RunSystems<TDSystem>(IEnumerable<TDSystem> systems,
            Action<TDSystem> runner, Action<TDSystem, long> performanceSender)
            where TDSystem : DSystem
        {
            foreach (TDSystem system in systems)
            {
                _world.Commit();
                if (DebugPerformance && performanceSender != null)
                {
                    DPerformance.Execute(() => runner(system),
                        ticks => performanceSender(system, ticks));
                }
                else
                {
                    runner(system);
                }
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

            _coroutineContext.RunEachFrame(() =>
            {
                if (_fpsService.FpsLastSecond >= MinWorkableFps)
                {
                    DMath.Divide(TimeScale * _time.DeltaTime, _time.DeltaTime, WorldUpdate);
                }
            }, true);
            _coroutineContext.RunEachFixedUpdate(() =>
            {
                if (_fpsService.FpsLastSecond >= MinWorkableFps)
                {
                    DMath.Divide(TimeScale * _time.DeltaTime, _time.DeltaTime, WorldFixedUpdate);
                }
            });
        }

        private void ConstructSystem<TDSystem>(TDSystem system)
            where TDSystem : DSystem
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

        public void AddInitializer<TDInitializer>() where TDInitializer : DInitializer, new() => 
            _initializers.Add(new TDInitializer());    
        
        public void AddDisposer<TDDisposer>() where TDDisposer : DDisposer, new() => 
            _disposers.Add(new TDDisposer());

        public void AddUpdateSystem<TDUpdateSystem>() where TDUpdateSystem : DUpdateSystem, new() => 
            _updateSystems.Add(new TDUpdateSystem());

        public void AddFixedSystem<TDFixedUpdateSystem>() where TDFixedUpdateSystem : DUpdateSystem, new() => 
            _fixedSystems.Add(new TDFixedUpdateSystem());

        public void AddOneFrame<TComponent>() where TComponent : struct, IComponent =>
            AddUpdateSystem<OneFrameCleanupSystem<TComponent>>();

        public void AddFixedOneFrame<TComponent>() where TComponent : struct, IComponent =>
            AddFixedSystem<OneFrameCleanupSystem<TComponent>>();

        public void FinishGame()
        {
            _coroutineContext.StopAllCoroutines();

            RunSystems(_disposers, s => s.Dispose(), null);

            _world.Dispose();
        }
    }
}