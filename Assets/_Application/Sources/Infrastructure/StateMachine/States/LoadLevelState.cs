using Sources.Game;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.SceneLoader;
using Sources.Infrastructure.Services.User;
using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.StateBase;
using Sources.UI.Screens;
using Sources.UI.System;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.StateMachine.States
{
    public class LoadLevelState : GameState
    {
        private ISceneLoaderService _sceneLoader;
        private Balance _balanceService;
        private LoadingScreen _loadingScreen;

        public LoadLevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _loadingScreen = DiContainer.Resolve<IUiService>().Get<LoadingScreen>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<Balance>();

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