using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Pool;
using Sources.Infrastructure.Services.Screens;
using Sources.Infrastructure.Services.Times;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Overlays;
using Sources.UI.System;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Infrastructure.StateMachine.States
{
    public class BootstrapState : GameState
    {
        public BootstrapState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            IApplicationService application = DiContainer.Resolve<IApplicationService>();
            IPhysicsService physics = DiContainer.Resolve<IPhysicsService>();
            IScreenService screen = DiContainer.Resolve<IScreenService>();
            ITimeService time = DiContainer.Resolve<ITimeService>();
            IUiService ui = DiContainer.Resolve<IUiService>();
            
            application.TargetFrameRate = Mathf.Min(60, screen.MaxDeviceFrameRate);
            physics.AutoSimulation = false;
            screen.SleepTimeout = SleepTimeout.NeverSleep;

            PreparePool();
            
            ui.Open<PerformanceScreen>();

            _stateMachine.Enter<LoadLevelState>();
        }
        
        private void PreparePool()
        {
            IPoolCreatorService poolCreatorService = DiContainer.Resolve<IPoolCreatorService>();
            Assets assets = DiContainer.Resolve<Assets>();

            foreach (CarMonoEntity carPrefab in assets.CarsAssets.CarPrefabs)
            {
                poolCreatorService.CreatePool(new PoolConfig(carPrefab, 40));
            }

            foreach (PlayerMonoEntity playerPrefab in assets.PlayersAssets.PlayerPrefabs)
            {
                poolCreatorService.CreatePool(new PoolConfig(playerPrefab, 40));
            }
        }
    }
}