using Sources.App.Core;
using Sources.App.Data;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Ui.Screens;
using Sources.App.Ui.Screens.Level;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class LevelState : GameState<LevelData>
    {
        private GameController _gameController;
        
        private LevelScreen _levelScreen;
        private IDiBuilder _diBuilder;

        public LevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter(LevelData levelData)
        {
            _diBuilder = DiBuilder.Create();

            _diBuilder.Register<ILevelContext>(levelData.LevelContext);
            _gameController = new GameController();
            
            IUiService ui = DiContainer.Resolve<IUiService>();
            
            _levelScreen = ui.Get<LevelScreen>();
            
            _levelScreen.RestartButtonClicked += LevelScreen_OnRestartButtonClicked;
            _levelScreen.ExitButtonClicked += LevelScreen_OnExitButtonClicked;
            _gameController.ForceReloadRequest += GameController_ForceReloadRequest;
            
            StartGame();
        }

        private void GameController_ForceReloadRequest()
        {
            FinishGame();
            _stateMachine.Enter<LoadLevelState>();
        }

        private void StartGame()
        {
            _gameController.StartGame();
        }
        
        private void LevelScreen_OnExitButtonClicked()
        {
            FinishGame();
            _stateMachine.Enter<MainUiState>();
        }

        private void LevelScreen_OnRestartButtonClicked()
        {
            FinishGame();
            _stateMachine.Enter<LoadLevelState>();
        }

        private void FinishGame()
        {
            _gameController.FinishGame();
        }

        protected override void OnExit()
        {
            _levelScreen.RestartButtonClicked -= LevelScreen_OnRestartButtonClicked;
            _levelScreen.ExitButtonClicked -= LevelScreen_OnExitButtonClicked;
            _gameController.ForceReloadRequest -= GameController_ForceReloadRequest;

            _gameController = null;

            _diBuilder.Dispose();
        }
    }
}