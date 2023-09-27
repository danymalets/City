using System;
using System.Collections.Generic;
using System.Linq;
using Sources.App.Ui.Screens.CarInputScreens;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.IapScreens;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.App.Ui.Screens.MainScreens;
using Sources.App.Ui.Screens.PerformanceScreens;
using Sources.App.Ui.Screens.PlayerInputScreens;
using Sources.App.Ui.Screens.SettingsScreens;
using Sources.Services.LocalizationServices;
using Sources.Services.UiServices.System;
using Sources.Utils.CommonUtils;
using Sources.Utils.Di;

namespace Sources.App.Ui.Base
{
    public class UiControllersService : IUiControllersService, IUiRefreshService, IUiCloseService,
        IInitializable, IDisposable
    {
        private readonly IUiViewsService _uiViews;
        private readonly TypeDictionary<ScreenControllerBase> _screenControllers = new();
        private readonly HashSet<ScreenControllerBase> _openedWindows = new();
        private readonly ILocalizationService _localizationService;

        public UiControllersService()
        {
            _uiViews = DiContainer.Resolve<IUiViewsService>();
            _localizationService = DiContainer.Resolve<ILocalizationService>();
        }

        void IInitializable.Initialize()
        {
            _screenControllers.AddRange(new ScreenControllerBase[]
            {
                new MainScreenController(_uiViews.Get<MainScreen>()),
                new SettingsScreenController(_uiViews.Get<SettingsScreen>()),
                new ShopScreenController(_uiViews.Get<ShopScreen>()),
                new CurrencyScreenController(_uiViews.Get<CurrencyScreen>()),
                new LevelScreenController(_uiViews.Get<LevelScreen>()),
                new CarInputScreenController(_uiViews.Get<CarInputScreen>()),
                new PlayerInputScreenController(_uiViews.Get<PlayerInputScreen>()),
                new LoadingScreenController(_uiViews.Get<LoadingScreen>()),
                new PerformanceScreenController(_uiViews.Get<PerformanceScreen>()),
            });

            foreach (ScreenControllerBase screenController in _screenControllers.Values)
            {
                screenController.Prepare();
                
                screenController.Opened += ScreenController_OnOpened;
                screenController.Closed += ScreenController_OnClosed;
            }
        }

        void IDisposable.Dispose()
        {
            foreach (ScreenControllerBase screenController in _screenControllers.Values)
            {
                screenController.Opened -= ScreenController_OnOpened;
                screenController.Closed -= ScreenController_OnClosed;
            }
        }

        public TWindowController Get<TWindowController>() where TWindowController : ScreenControllerBase => 
            _screenControllers.Get<TWindowController>();
        
        void IUiRefreshService.Refresh()
        {
            foreach (ScreenControllerBase screenController in _openedWindows.ToArray())
            {
                screenController.Refresh();
            }
        }

        void IUiCloseService.CloseAll()
        {
            foreach (ScreenControllerBase screenController in _openedWindows.ToArray())
            {
                if (!screenController.IsAlwaysOpen)
                {
                    screenController.Close(true);
                }
            }
        }

        private void ScreenController_OnOpened(ScreenControllerBase screenController)
        {
            _openedWindows.Add(screenController);
        }

        private void ScreenController_OnClosed(ScreenControllerBase screenController)
        {
            _openedWindows.Remove(screenController);
        }
    }
}