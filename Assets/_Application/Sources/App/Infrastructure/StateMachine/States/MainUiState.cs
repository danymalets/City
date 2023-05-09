using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Ui.Screens.Level;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class MainUiState : GameState
    {
        private MainScreen _mainScreen;
        private IUiCloseService _uiCloseService;

        public MainUiState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _mainScreen = DiContainer.Resolve<IUiService>().Get<MainScreen>();
            _uiCloseService = DiContainer.Resolve<IUiCloseService>();
            _mainScreen.Open();

            _mainScreen.PlayClicked += OnPlayClicked;
        }

        private void OnPlayClicked()
        {
            _stateMachine.Enter<LoadLevelState>();
        }
        
        protected override void OnExit()
        {
            _mainScreen.PlayClicked -= OnPlayClicked;

            _uiCloseService.CloseAll();
            _mainScreen = null;
            _uiCloseService = null;
        }
    }
}