using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.App.Infrastructure.StateMachine.Machine;
using _Application.Sources.App.Infrastructure.StateMachine.StateBase;
using _Application.Sources.App.UI.Overlays;
using _Application.Sources.CommonServices.ApplicationServices;
using _Application.Sources.CommonServices.PhysicsServices;
using _Application.Sources.CommonServices.PoolServices;
using _Application.Sources.CommonServices.ScreenServices;
using _Application.Sources.CommonServices.TimeServices;
using _Application.Sources.CommonServices.UiServices.System;
using _Application.Sources.Utils.Di;
using Sources.ProjectServices.AssetsServices;
using UnityEngine;

namespace _Application.Sources.App.Infrastructure.StateMachine.States
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

            foreach (ICarMonoEntity carPrefab in assets.CarsAssets.CarPrefabs)
            {
                poolCreatorService.CreatePool(new PoolConfig(carPrefab, 40));
            }

            foreach (IPlayerMonoEntity playerPrefab in assets.PlayersAssets.PlayerPrefabs)
            {
                poolCreatorService.CreatePool(new PoolConfig(playerPrefab, 40));
            }
        }
    }
}