using System;
using System.Collections.Generic;
using System.Linq;
using PlasticGui.WorkspaceWindow;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.CarInputScreens;
using Sources.App.Ui.Screens.CurrencyScreens;
using Sources.App.Ui.Screens.Debug_TODO;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LoadingScreens;
using Sources.App.Ui.Screens.MainScreens;
using Sources.App.Ui.Screens.PerformanceScreens;
using Sources.App.Ui.Screens.PlayerInputScreens;
using Sources.App.Ui.Screens.SettingsScreens;
using Sources.App.Ui.Screens.ShopScreens;
using Sources.Services.LocalizationServices;
using Sources.Utils.CommonUtils;
using Sources.Utils.CommonUtils.Collections;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;

namespace Sources.App.Ui.Base
{
    public class UiControllersService : IUiControllersService, IUiRefreshService, IUiCloseService,
        IInitializable, IDisposable
    {
        private readonly TypeDictionary<ScreenControllerBase> _screenControllers = new();
        private readonly TypeDictionary<GameScreen> _screens = new();
        private readonly HashSet<ScreenControllerBase> _openedWindows = new();
        private readonly ILocalizationService _localizationService;

        public UiControllersService(UiViews uiViews)
        {
            _screens.AddRange(uiViews.GameScreens);
            _localizationService = DiContainer.Resolve<ILocalizationService>();
        }

        void IInitializable.Initialize()
        {
            foreach (GameScreen screen in _screens.Select(s => s.Value))
            {
                screen.gameObject.Disable();
            }
            
            _screenControllers.AddRange(new ScreenControllerBase[]
            {
                new MainScreenController(_screens.Get<MainScreen>()),
                new SettingsScreenController(_screens.Get<SettingsScreen>()),
                new ShopScreenController(_screens.Get<ShopScreen>()),
                new CurrencyScreenController(_screens.Get<CurrencyScreen>()),
                new LevelScreenController(_screens.Get<LevelScreen>()),
                new CarInputScreenController(_screens.Get<CarInputScreen>()),
                new PlayerInputScreenController(_screens.Get<PlayerInputScreen>()),
                new LoadingScreenController(_screens.Get<LoadingScreen>()),
                new PerformanceScreenController(_screens.Get<PerformanceScreen>()),
                new DebugMenuScreenController(_screens.Get<DebugMenuScreen>()),
            });

            foreach (ScreenControllerBase screenController in _screenControllers.Values)
            {
                screenController.Prepare();
                
                screenController.Opened += ScreenController_OnOpened;
                screenController.Closed += ScreenController_OnClosed;
            }

            _localizationService.LocalizationChanged += LocalizationService_OnLocalizationChanged;
        }

        void IDisposable.Dispose()
        {
            foreach (ScreenControllerBase screenController in _screenControllers.Values)
            {
                screenController.Opened -= ScreenController_OnOpened;
                screenController.Closed -= ScreenController_OnClosed;
            }
            
            _localizationService.LocalizationChanged -= LocalizationService_OnLocalizationChanged;
        }

        public TWindowController Get<TWindowController>() where TWindowController : ScreenControllerBase => 
            _screenControllers.Get<TWindowController>();

        public void Refresh()
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

        private void LocalizationService_OnLocalizationChanged()
        {
            Refresh();
        }
    }
}