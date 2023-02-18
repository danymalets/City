using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.Fps;
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

            application.TargetFrameRate = 60;//screen.MaxDeviceFrameRate;
            time.PhysicsUpdateCount = DRandom.Bool() ? 50 : 30;
            physics.AutoSimulation = false;
            screen.SleepTimeout = SleepTimeout.NeverSleep;

            ui.Open<PerformanceScreen>();

            _stateMachine.Enter<LoadLevelState>();
        }
    }
}