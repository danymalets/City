using Sources.App.Game;
using Sources.App.Game.UI.Screens;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.Data;
using Sources.Data.Common;
using Sources.Services.AssetsManager;
using Sources.Services.Di;
using Sources.Services.SceneLoader;
using Sources.Services.Ui.System;
using Sources.Services.UserService;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class LoadLevelState : GameState
    {
        private ISceneLoaderService _sceneLoader;
        private Services.BalanceManager.Balance _balanceService;
        private LoadingScreen _loadingScreen;

        public LoadLevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _loadingScreen = DiContainer.Resolve<IUiService>().Get<LoadingScreen>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<Services.BalanceManager.Balance>();

            int level = DiContainer.Resolve<IUserAccessService>()
                .User.Progress.CurrentLevel;

            string cityScene = DiContainer.Resolve<Assets>().CitySceneName;

            //int realLevel = GetRealLevel(level, _balanceService.LevelsCount);

            //LevelBalance balance = _balanceService.GetLevelBalance(realLevel);
            
            _loadingScreen.Open();
            
            SceneManager.LoadScene($"Empty");
            
            _sceneLoader.LoadScene<ILevelContext>(cityScene, levelContext => 
                EnterLevelState(new LevelData(level, levelContext)));
        }

        private void EnterLevelState(LevelData levelData)
        {
            _stateMachine.Enter<LevelState, LevelData>(levelData);
        }

        private int GetRealLevel(int level, int levelsCount) => 
            (level - 1) % levelsCount + 1;
    }
}