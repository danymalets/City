using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Game.UI.Overlays;
using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.ApplicationCycle;
using Sources.App.Infrastructure.Services.AssetsManager;
using Sources.App.Infrastructure.Services.Physics;
using Sources.App.Infrastructure.Services.Pool;
using Sources.App.Infrastructure.Services.Screens;
using Sources.App.Infrastructure.Services.Times;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States
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