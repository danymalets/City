using System;
using System.Collections.Generic;
using System.Linq;
using Sources.App.Ui.Overlays;
using Sources.App.Ui.Screens;
using Sources.App.Ui.Screens.Level;
using Sources.App.Ui.ToMove.CarInputScreens;
using Sources.App.Ui.ToMove.LevelScreens;
using Sources.App.Ui.ToMove.LoadingScreens;
using Sources.App.Ui.ToMove.MapScreens;
using Sources.App.Ui.ToMove.PerformanceScreens;
using Sources.App.Ui.ToMove.PlayerInputScreens;
using Sources.Services.UiServices.System;
using Sources.Utils.CommonUtils;
using Sources.Utils.Di;

namespace Sources.App.Ui.Controllers
{
    public class UiControllersService : IUiControllersService, IUiRefreshService, IUiCloseService,
        IInitializable, IDisposable
    {
        private readonly IUiViewsService _uiViews;
        private readonly TypeDictionary<ScreenControllerBase> _screenControllers = new();
        private readonly HashSet<ScreenControllerBase> _openedWindows = new();

        public UiControllersService()
        {
            _uiViews = DiContainer.Resolve<IUiViewsService>();
        }

        void IInitializable.Initialize()
        {
            _screenControllers.AddRange(new ScreenControllerBase[]
            {
                new MainScreenController(_uiViews.Get<MainScreen>()),
                new LevelScreenController(_uiViews.Get<LevelScreen>()),
                new CarInputScreenController(_uiViews.Get<CarInputScreen>()),
                new PlayerInputScreenController(_uiViews.Get<PlayerInputScreen>()),
                new MapScreenController(_uiViews.Get<MapScreen>()),
                new LoadingScreenController(_uiViews.Get<LoadingScreen>()),
                new PerformanceScreenController(_uiViews.Get<PerformanceScreen>()),
            });

            foreach (ScreenControllerBase screenController in _screenControllers.Values)
            {
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
                screenController.Close(true);
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