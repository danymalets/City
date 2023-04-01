using Sources.App.Game;
using Sources.App.Game.UI.Screens;
using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.AssetsManager;
using Sources.Di;
using Sources.Services.SceneLoader;
using Sources.User;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class LoadLevelState : GameState
    {
        private ISceneLoaderService _sceneLoader;
        private Balance.Balance _balanceService;
        private LoadingScreen _loadingScreen;

        public LoadLevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _loadingScreen = DiContainer.Resolve<IUiService>().Get<LoadingScreen>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<Balance.Balance>();

            int level = DiContainer.Resolve<IUserAccessService>()
                .User.Progress.CurrentLevel;

            string cityScene = DiContainer.Resolve<Assets>().CitySceneName;

            //int realLevel = GetRealLevel(level, _balanceService.LevelsCount);

            //LevelBalance balance = _balanceService.GetLevelBalance(realLevel);
            
            _loadingScreen.Open();
            
            SceneManager.LoadScene($"Empty");
            
            _sceneLoader.LoadScene<LevelContext>(cityScene, levelContext => 
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