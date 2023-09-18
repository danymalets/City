using System;
using Sources.App.Core.Ecs;
using Sources.App.Data.Constants;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.AudioServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Data;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.Services.AnalyticsServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.FpsServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Core
{
    public class GameController
    {
        private readonly LevelScreenController _levelScreen;

        private readonly ILevelContext _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private readonly Game _game;
        private readonly IDiBuilder _diBuilder;
        private readonly LoadingScreenController _loadingScreen;
        private readonly IFpsService _fpsService;
        private readonly CoroutineContext _coroutineContext;
        private readonly Preferences _userPreferences;
        private readonly IAnalyticsService _analytics;

        public event Action ForceReloadRequested; 

        public GameController()
        {
            IUiControllersService
                uiControllers = DiContainer.Resolve<IUiControllersService>();
            _fpsService = DiContainer.Resolve<IFpsService>();
            _userPreferences = DiContainer.Resolve<IUserAccessService>().User.Preferences;
            _analytics = DiContainer.Resolve<IAnalyticsService>();

            _diBuilder = DiBuilder.Create();

            _game = new Game();
            
            _levelScreen = uiControllers.Get<LevelScreenController>();
            _loadingScreen = uiControllers.Get<LoadingScreenController>();

            _uiClose = DiContainer.Resolve<IUiCloseService>();

            _audio = DiContainer.Resolve<IAudioService>();

            _coroutineContext = new CoroutineContext();
        }
        
        public void StartGame()
        {
            if (_userPreferences.BestQualityForDevice == null)
            {
                _userPreferences.SelectedQuality = QualityType.High;
            }
            
            _analytics.SendLevelStarted(1);
            
            _levelScreen.Open(_level);

            _game.StartGame();

            _coroutineContext.ChangeValue(0f, 1f, 3f, value => 
                _loadingScreen.SetProgress(value));
            
            _fpsService.RunWhenFpsStabilizes(() =>
            {
                _coroutineContext.StopAllCoroutines();
                _loadingScreen.Close();

                if (_userPreferences.BestQualityForDevice == null)
                {
                    if (_fpsService.FpsLastSecond > Consts.MinFpsForHighQuality)
                    {
                        _userPreferences.BestQualityForDevice = QualityType.High;
                        _userPreferences.SelectedQuality = QualityType.High;
                    }
                    else
                    {
                        _userPreferences.BestQualityForDevice = QualityType.Low;
                        _userPreferences.SelectedQuality = QualityType.Low;
                        
                        ForceReloadRequested?.Invoke();
                    }
                }
            });
        }

        public void FinishGame()
        {
            _game.FinishGame();
            _audio.StopAll();
            _uiClose.CloseAll();

            _diBuilder.Dispose();
        }
    }
}