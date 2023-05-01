using Sources.App.Core;
using Sources.App.Data;
using Sources.App.Data.Common;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
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
        private WinScreen _winScreen;
        private LoseScreen _loseScreen;
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
            _winScreen = ui.Get<WinScreen>();
            _loseScreen = ui.Get<LoseScreen>();
            
            _levelScreen.RestartButtonClicked += LevelScreen_OnRestartButtonClicked;
            _winScreen.NextButtonClicked += WinScreen_OnNextButtonClicked;
            _loseScreen.RetryButtonClicked += LoseScreen_OnRetryButtonClicked;
            
            StartGame();
        }

        private void StartGame()
        {
            _gameController.StartGame();
        }
        
        private void LevelScreen_OnRestartButtonClicked()
        {
            FinishGame();
        }

        private void WinScreen_OnNextButtonClicked()
        {
            FinishGame();
        }

        private void LoseScreen_OnRetryButtonClicked()
        {
            FinishGame();
        }

        private void FinishGame()
        {
            _gameController.FinishGame();
            _stateMachine.Enter<LoadLevelState>();
        }

        protected override void OnExit()
        {
            _levelScreen.RestartButtonClicked -= LevelScreen_OnRestartButtonClicked;
            _winScreen.NextButtonClicked -= WinScreen_OnNextButtonClicked;
            _loseScreen.RetryButtonClicked -= LoseScreen_OnRetryButtonClicked;

            _diBuilder.Dispose();
        }
    }
}