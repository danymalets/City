using Sources.App.Data.MonoEntities;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.UI.Overlays;
using Sources.CommonServices.ApplicationServices;
using Sources.CommonServices.PhysicsServices;
using Sources.CommonServices.PoolServices;
using Sources.CommonServices.ScreenServices;
using Sources.CommonServices.TimeServices;
using Sources.CommonServices.UiServices.System;
using Sources.ProjectServices.AssetsServices;
using Sources.Utils.Di;
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