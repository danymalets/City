using Sources.App.Core;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.Services.AdsServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class LevelState : GameState<LevelData>
    {
        private GameController _gameController;
        
        private LevelScreenController _levelScreen;
        private IDiBuilder _diBuilder;
        private IAdsService _adsService;

        public LevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter(LevelData levelData)
        {
            _diBuilder = DiBuilder.Create();

            _diBuilder.Register<ILevelContext>(levelData.LevelContext);
            _gameController = new GameController();

            _adsService = DiContainer.Resolve<IAdsService>();

            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            _levelScreen = uiControllers.Get<LevelScreenController>();
            
            _levelScreen.RestartButtonClicked += LevelScreen_OnRestartButtonClicked;
            _levelScreen.ExitButtonClicked += LevelScreen_OnExitButtonClicked;
            _gameController.ForceReloadRequested += GameControllerForceReloadRequested;
            
            StartGame();
        }

        private void GameControllerForceReloadRequested()
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

            if (_adsService.IsRewardedAvailable)
            {
                _adsService.ShowRewarded(() =>
                {
                    Debug.Log($"suc");
                    EnterMainUi();
                }, () =>
                {
                    Debug.Log($"fail");
                    EnterMainUi();
                });
            }
            else
            {
                Debug.Log($"reward not available");
                EnterMainUi();
            }
        }

        private void EnterMainUi()
        {
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
            _gameController.ForceReloadRequested -= GameControllerForceReloadRequested;

            _gameController = null;

            _diBuilder.Dispose();
        }
    }
}