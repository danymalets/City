using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Screens;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Overlays;
using Sources.UI.System;
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
            IUiService ui = DiContainer.Resolve<IUiService>();
            
            application.TargetFrameRate = screen.MaxDeviceFrameRate;
            // Time.fixedDeltaTime = 1 / 30f;
            physics.AutoSimulation = false;

            ui.Open<PerformanceScreen>();
            
            _stateMachine.Enter<LoadLevelState>();
        }
    }
}