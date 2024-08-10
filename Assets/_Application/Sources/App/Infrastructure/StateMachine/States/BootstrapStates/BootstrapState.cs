using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.MainUiStates;
using Sources.App.Services.AssetsServices;
using Sources.App.Ui.Base;
using Sources.Services.ApplicationServices;
using Sources.Services.PhysicsServices;
using Sources.Services.PoolServices;
using Sources.Services.ScreenServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.BootstrapStates
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
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            application.TargetFrameRate = Mathf.Min(60, screen.MaxDeviceFrameRate);
            physics.AutoSimulation = false;
            screen.SleepTimeout = SleepTimeout.NeverSleep;

            PreparePool();

#if FORCE_DEBUG
            uiControllers.Get<PerformanceScreenController>().Open();
            uiControllers.Get<DebugMenuScreenController>().Open();
#endif

            _stateMachine.Enter<MainUiState>();
        }
        
        private void PreparePool()
        {
            IPoolCreatorService poolCreatorService = DiContainer.Resolve<IPoolCreatorService>();
            Assets assets = DiContainer.Resolve<Assets>();

        }
    }
}