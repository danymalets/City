using Sources.Game;
using Sources.Game.Controllers;
using Sources.Game.StaticData;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Screens;
using Sources.UI.Screens.Level;
using Sources.UI.System;
using static UnityEngine.Object;

namespace Sources.Infrastructure.StateMachine.States
{
    public class LevelStateBase : GameState<LevelData>
    {
        private GameController _gameController;
        
        private LevelScreen _levelScreen;
        private WinScreen _winScreen;
        private LoseScreen _loseScreen;

        public LevelStateBase(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter(LevelData levelData)
        {
            _levelScreen = UiSystem.Get<LevelScreen>();
            _winScreen = UiSystem.Get<WinScreen>();
            _loseScreen = UiSystem.Get<LoseScreen>();
            
            _levelScreen.RestartButtonClicked += LevelScreen_OnRestartButtonClicked;
            _winScreen.NextButtonClicked += WinScreen_OnNextButtonClicked;
            _loseScreen.RetryButtonClicked += LoseScreen_OnRetryButtonClicked;
            
            StartGame(levelData);
        }

        private void StartGame(LevelData levelData)
        {
            var levelStaticData = FindObjectOfType<LevelStaticData>();
            _gameController = new GameController(levelData.Level, levelData.LevelBalance, levelStaticData);
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
            _gameController.EndGame();
            _stateMachine.Enter<LoadLevelStateBase>();
        }

        protected override void OnExit()
        {
            _levelScreen.RestartButtonClicked -= LevelScreen_OnRestartButtonClicked;
            _winScreen.NextButtonClicked -= WinScreen_OnNextButtonClicked;
            _loseScreen.RetryButtonClicked -= LoseScreen_OnRetryButtonClicked;
        }
    }
}