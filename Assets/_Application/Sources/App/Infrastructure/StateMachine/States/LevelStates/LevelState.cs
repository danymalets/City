using Sources.App.Core;
using Sources.App.Core.Services.Quality;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.MainUiStates;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.PausePopups;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States.LevelStates
{
    public class LevelState : GameState
    {
        private GameController _gameController;
        private PausePopupController _pausePopupController;
        private IQualityChangerService _qualityChanger;
        private IUserAccessService _userAccess;

        public LevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _qualityChanger = DiContainer.Resolve<IQualityChangerService>();
            _userAccess = DiContainer.Resolve<IUserAccessService>();

            _qualityChanger.SetQuality(_userAccess.User.Preferences.SelectedQuality);
            
            _pausePopupController = DiContainer.Resolve<IUiControllersService>().Get<PausePopupController>();

            _gameController = new GameController();
            
            _pausePopupController.RestartButtonClicked += PausePopupController_OnRestartButtonClicked;
            _pausePopupController.ExitButtonClicked += PausePopupController_OnExitButtonClicked;
            _gameController.ForceReloadRequested += GameController_OnForceReloadRequested;

            _gameController.StartGame();
        }

        private void GameController_OnForceReloadRequested()
        {
            FinishGame();
            EnterMainUi();
        }

        private void PausePopupController_OnExitButtonClicked()
        {
            FinishGame();
            EnterMainUi();
        }

        private void EnterMainUi()
        {
            _stateMachine.Enter<MainUiState>();
        }

        private void PausePopupController_OnRestartButtonClicked()
        {
            FinishGame();
            EnterMainUi();
        }

        private void FinishGame()
        {
            _gameController.FinishGame();
        }

        protected override void OnExit()
        {
            _pausePopupController.RestartButtonClicked -= PausePopupController_OnRestartButtonClicked;
            _pausePopupController.ExitButtonClicked -= PausePopupController_OnExitButtonClicked;
            _gameController.ForceReloadRequested -= GameController_OnForceReloadRequested;

            _gameController = null;
        }
    }
}