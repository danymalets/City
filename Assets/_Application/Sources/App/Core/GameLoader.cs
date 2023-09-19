using System;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.IdleCarSpawns;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;
using UnityEngine.SceneManagement;

namespace Sources.App.Core
{
    public class GameLoader
    {
        private readonly ISceneLoaderService _sceneLoader;
        private readonly LoadingScreenController _loadingScreenController;
        private readonly Balance _balanceService;

        public GameLoader()
        {
            _loadingScreenController = DiContainer.Resolve<IUiControllersService>().Get<LoadingScreenController>();

            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _balanceService = DiContainer.Resolve<Balance>();
        }

        public void LoadGame(Action<LevelData> onLoaded)
        {
            int level = DiContainer.Resolve<IUserAccessService>()
                .User.Progress.CurrentLevel;

            string cityScene = DiContainer.Resolve<Assets>().CitySceneName;

            _loadingScreenController.Open();
            
            SceneManager.LoadScene($"Empty");
            
            _sceneLoader.LoadScene<ILevelContext>(cityScene, 
                levelContext => onLoaded(new LevelData(level, levelContext)));
        }
    }
}