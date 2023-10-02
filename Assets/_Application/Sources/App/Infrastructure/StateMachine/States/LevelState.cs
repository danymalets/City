using Sources.App.Core;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.QualityServices;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.Services.AdsServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class LevelState : GameState
    {
        private GameController _gameController;
        private LevelScreenController _levelScreen;
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
            
            _levelScreen = DiContainer.Resolve<IUiControllersService>().Get<LevelScreenController>();

            _gameController = new GameController();
            
            _levelScreen.RestartButtonClicked += LevelScreen_OnRestartButtonClicked;
            _levelScreen.ExitButtonClicked += LevelScreen_OnExitButtonClicked;
            _gameController.ForceReloadRequested += GameControllerForceReloadRequested;

            _gameController.StartGame();
        }

        private void GameControllerForceReloadRequested()
        {
            FinishGame();
            EnterMainUi();
        }

        private void LevelScreen_OnExitButtonClicked()
        {
            FinishGame();
            EnterMainUi();
        }

        private void EnterMainUi()
        {
            _stateMachine.Enter<MainUiState>();
        }

        private void LevelScreen_OnRestartButtonClicked()
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
            _levelScreen.RestartButtonClicked -= LevelScreen_OnRestartButtonClicked;
            _levelScreen.ExitButtonClicked -= LevelScreen_OnExitButtonClicked;
            _gameController.ForceReloadRequested -= GameControllerForceReloadRequested;

            _gameController = null;
        }
    }
}