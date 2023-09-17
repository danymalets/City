using Sources.App.Data;
using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.Services.SceneLoaderServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;
using UnityEngine.SceneManagement;

namespace Sources.App.Infrastructure.StateMachine.States
{
    public class LoadLevelState : GameState
    {
        private ISceneLoaderService _sceneLoader;
        private Balance _balanceService;
        private LoadingScreenController _loadingScreenController;

        public LoadLevelState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            _loadingScreenController = DiContainer.Resolve<IUiControllersService>().Get<LoadingScreenController>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<Balance>();

            int level = DiContainer.Resolve<IUserAccessService>()
                .User.Progress.CurrentLevel;

            string cityScene = DiContainer.Resolve<Assets>().CitySceneName;

            _loadingScreenController.Open();
            
            SceneManager.LoadScene($"Empty");
            
            _sceneLoader.LoadScene<ILevelContext>(cityScene, 
                levelContext => EnterLevelState(new LevelData(level, levelContext)));
        }

        private void EnterLevelState(LevelData levelData)
        {
            _stateMachine.Enter<LevelState, LevelData>(levelData);
        }

        private int GetRealLevel(int level, int levelsCount) => 
            (level - 1) % levelsCount + 1;
    }
}