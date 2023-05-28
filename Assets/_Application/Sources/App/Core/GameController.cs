using System;
using Sources.App.Core.Ecs;
using Sources.App.Data.Constants;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.AudioServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Data;
using Sources.App.Ui.Screens;
using Sources.App.Ui.Screens.Input;
using Sources.App.Ui.Screens.Level;
using Sources.App.Ui.Screens.Map;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.FpsServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Core
{
    public class GameController
    {
        private readonly LevelScreen _levelScreen;
        private readonly CarInputScreen _carInputScreen;

        private readonly ILevelContext _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private Game _game;
        private readonly IDiBuilder _diBuilder;
        private readonly LoadingScreen _loadingScreen;
        private readonly IFpsService _fpsService;
        private readonly CoroutineContext _coroutineContext;
        private readonly MapScreen _mapScreen;
        private readonly Preferences _userPreferences;

        public event Action ForceReloadRequest; 

        public GameController()
        {
            IUiService ui = DiContainer.Resolve<IUiService>();
            _fpsService = DiContainer.Resolve<IFpsService>();
            _userPreferences = DiContainer.Resolve<IUserAccessService>().User.Preferences;

            _diBuilder = DiBuilder.Create();


            _game = new Game();
            
            _levelScreen = ui.Get<LevelScreen>();
            _mapScreen = ui.Get<MapScreen>();
            _loadingScreen = ui.Get<LoadingScreen>();
            _carInputScreen = ui.Get<CarInputScreen>();

            _uiClose = DiContainer.Resolve<IUiCloseService>();

            _audio = DiContainer.Resolve<IAudioService>();

            _coroutineContext = DiContainer.Resolve<ICoroutineContextCreatorService>()
                .CreateCoroutineContext();

        }
        
        public void StartGame()
        {
            //_audio.PlayMusic(MusicType.RoadNoise);

            if (_userPreferences.BestQualityForDevice == null)
            {
                _userPreferences.SelectedQuality = QualityType.High;
            }
            
            _levelScreen.Open(_level);
            _mapScreen.Open();

            _game.StartGame();

            _coroutineContext.ChangeValue(0.05f, 0.95f, 3f, value => 
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
                        
                        ForceReloadRequest?.Invoke();
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