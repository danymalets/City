using Sources.App.Core;
using Sources.App.Core.Services.Quality;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States.MainUiStates;
using Sources.App.Services.GameRunnerServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.PausePopups;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States.LevelStates
{
    public class LevelState : GameState<RunMatchSettings>
    {
        private GameController _gameController;
        private PausePopupController _pausePopupController;
        private RunMatchSettings _runMatchSettings;

        public LevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter(RunMatchSettings runMatchSettings)
        {
            _runMatchSettings = runMatchSettings;
            _pausePopupController = DiContainer.Resolve<IUiControllersService>().Get<PausePopupController>();
            
            IQualityChangerService qualityChangerService = DiContainer.Resolve<IQualityChangerService>();
            UserPreferences userPreferences = DiContainer.Resolve<IUserAccessService>().User.UserPreferences;
            qualityChangerService.SetQuality(userPreferences.SelectedQuality);
            
            _gameController = new GameController();

            _pausePopupController.RestartButtonClicked += PausePopupController_OnRestartButtonClicked;
            _pausePopupController.ExitButtonClicked += PausePopupController_OnExitButtonClicked;
            _gameController.ForceReloadRequested += GameController_OnForceReloadRequested;
            
            _gameController.StartGame();
        }

        private void GameController_OnForceReloadRequested()
        {
            ForceRestartGame();
        }

        private void PausePopupController_OnExitButtonClicked()
        {
            FinishGameAndEnterMainMenu();
        }

        private void PausePopupController_OnRestartButtonClicked()
        {
            ForceRestartGame();
        }

        private void FinishGameAndEnterMainMenu()
        {
            FinishGame();
            _stateMachine.Enter<MainUiState, bool>(false);
        }

        private void ForceRestartGame()
        {
            FinishGame();
            _stateMachine.Enter<LevelState, RunMatchSettings>(_runMatchSettings);
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