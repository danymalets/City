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
        private readonly SystemsPerformance _systemsPerformance;

        public Filter Filter => _world.Filter;

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

            if (DebugPerformance)
            {
                _coroutineContext.RunEachSeconds(3f, () =>
                {
                    _systemsPerformance.LogData();
                    _systemsPerformance.Reset();
                });
            }
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

            RunSystems(_initializers, s => s.Initialize(), null);

            _coroutineContext.RunEachFrame(() =>
            {
                if (_fpsService.FpsLastSecond >= MinWorkableFps)
                {
                    float totalDeltaTime = TimeScale * _time.DeltaTime;

                    while (DMath.Greater(totalDeltaTime, 0))
                    {
                        float deltaTime = Mathf.Min(totalDeltaTime, _time.FixedDeltaTime);
                        WorldUpdate(deltaTime);
                        totalDeltaTime -= deltaTime;
                    }
                }
            }, true);
            _coroutineContext.RunEachFixedUpdate(() =>
            {
                if (_fpsService.FpsLastSecond >= MinWorkableFps)
                {
                    float totalDeltaTime = TimeScale * _time.FixedDeltaTime;

                    while (DMath.Greater(totalDeltaTime, 0))
                    {
                        float deltaTime = Mathf.Min(totalDeltaTime, _time.FixedDeltaTime);
                        WorldFixedUpdate(deltaTime);
                        totalDeltaTime -= deltaTime;
                    }
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
            _world.Dispose();
        }

        public void AddFixedOneFrame<TComponent>() where TComponent : struct, IComponent =>
            AddFixedSystem<OneFrameCleanupSystem<TComponent>>();
    }
}