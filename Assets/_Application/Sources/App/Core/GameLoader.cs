using System;
using Sources.App.Data.Constants;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.FpsServices;
using Sources.Services.SceneLoaderServices;
using Sources.Services.TimeServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core
{
    public class GameLoader
    {
        private const float StartProgressValue = 0.1f;
        
        private readonly IFpsService _fpsService;
        private readonly UserPreferences _userUserPreferences;
        private readonly ITimeService _timeService;
        private readonly CoroutineContext _coroutineContext;
        private readonly LevelScreenController _levelScreen;
        private readonly LoadingScreenController _loadingScreenController;
        private readonly ISceneLoaderService _sceneLoader;


        public GameLoader()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();
            _timeService = DiContainer.Resolve<ITimeService>();
            _userUserPreferences = DiContainer.Resolve<IUserAccessService>().User.UserPreferences;
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();

            _levelScreen = uiControllers.Get<LevelScreenController>();
            _loadingScreenController = uiControllers.Get<LoadingScreenController>();
            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
            _coroutineContext = new CoroutineContext();
        }

        public void StartLoadGame(Action<ILevelContext> onSceneLoaded, Action onLoaded, Action onReloadRequest)
        {
            LoadGameScene(levelContext =>
            {
                onSceneLoaded?.Invoke(levelContext);
                StartFpsStabilizer(3f, onLoaded, onReloadRequest);
            });
        }

        private void LoadGameScene(Action<ILevelContext> onSceneLoaded)
        {
            string cityScene = DiContainer.Resolve<Assets>().CitySceneName;

            _loadingScreenController.Open();

            _coroutineContext.RunNextFrame(() =>
            {
                _loadingScreenController.SetProgress(StartProgressValue / 2);

                _coroutineContext.RunNextFrame(() =>
                {
                    _loadingScreenController.SetProgress(StartProgressValue);
                    
                    _coroutineContext.RunNextFrame(() =>
                    {
                        _sceneLoader.LoadScene<ILevelContext>(cityScene,
                            levelContext => onSceneLoaded?.Invoke(levelContext));
                    });
                });
            });
        }

        private void StartFpsStabilizer(float minTime, Action onLoaded, Action onReloadRequest)
        {
            _levelScreen.Open();
            float time = _timeService.Time;
            
            _coroutineContext.ChangeValue(StartProgressValue, 1f, minTime, value => 
                _loadingScreenController.SetProgress(value));
            
            _fpsService.RunWhenFpsStabilizes(() =>
            {
                _coroutineContext.RunWhen(() => _timeService.Time >= time + minTime, () =>
                {
                    _loadingScreenController.Close();
                    
                    bool shouldReload = false;
                    
                    if (_userUserPreferences.BestQualityForDevice == null)
                    {
                        if (_fpsService.FpsLastSecond > Consts.MinFpsForHighQuality)
                        {
                            _userUserPreferences.BestQualityForDevice = QualityType.High;
                        }
                        else
                        {
                            _userUserPreferences.BestQualityForDevice = QualityType.Low;
                            _userUserPreferences.SelectedQuality = QualityType.Low;

                            shouldReload = true;
                        }
                    }
                    
                    if (shouldReload)
                    {
                        onReloadRequest?.Invoke();
                    }
                    else
                    {
                        onLoaded?.Invoke();
                    }
                });
            });
        }
    }
}