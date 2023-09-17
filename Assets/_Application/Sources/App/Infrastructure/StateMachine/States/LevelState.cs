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
            _adsService.ShowRewarded(() =>
            {
                Debug.Log($"suc");
                _stateMachine.Enter<LoadLevelState>();
            }, () =>
            {
                Debug.Log($"fail");
            });
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