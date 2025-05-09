using System;
using Cysharp.Threading.Tasks;
using Sources.App.Data.Constants;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.AudioServices;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.Services.FpsServices;
using Sources.Services.GameLoopServices;
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
        private readonly LevelScreenController _levelScreen;
        private readonly LoadingScreenController _loadingScreenController;
        private readonly ISceneLoaderService _sceneLoader;
        private readonly IGameLoopService _gameLoopService;
        private readonly IAudioService _audioService;
        
        public GameLoader()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();
            _timeService = DiContainer.Resolve<ITimeService>();
            _audioService = DiContainer.Resolve<IAudioService>();
            _userUserPreferences = DiContainer.Resolve<IUserAccessService>().User.UserPreferences;
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();

            _levelScreen = uiControllers.Get<LevelScreenController>();
            _loadingScreenController = uiControllers.Get<LoadingScreenController>();
            _gameLoopService = DiContainer.Resolve<IGameLoopService>();

            
            _sceneLoader = DiContainer.Resolve<ISceneLoaderService>();
        }

        public async UniTask<bool> StartLoadGame(Action<ILevelContext> onSceneLoaded)
        {
            _audioService.SetCoreMusicsGroupVolume(0);
            var levelContext = await LoadGameScene();
            
            onSceneLoaded?.Invoke(levelContext);
            
            var success = await StartFpsStabilizer(3f);

            if (success)
            {
                _audioService.StopAll();
                _audioService.SetCoreMusicsGroupVolume(1);
            }

            return success;
        }

        private async UniTask<ILevelContext> LoadGameScene()
        {
            string cityScene = DiContainer.Resolve<Assets>().CitySceneName;

            _loadingScreenController.Open();

            await UniTask.NextFrame();
            
            _loadingScreenController.SetProgress(StartProgressValue / 2);

            await UniTask.NextFrame();

            _loadingScreenController.SetProgress(StartProgressValue);
            
            await UniTask.NextFrame();

            return await _sceneLoader.LoadScene<ILevelContext>(cityScene);
        }

        private async UniTask<bool> StartFpsStabilizer(float minTime)
        {
            _levelScreen.Open();
            float time = _timeService.Time;
            
            _gameLoopService.ChangeValue(StartProgressValue, 1f, minTime, value => 
                _loadingScreenController.SetProgress(value));

            await _fpsService.WaitForStableFps();

            UniTask.WaitUntil(() => _timeService.Time >= time + minTime);
                
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

            return !shouldReload;
        }
    }
}