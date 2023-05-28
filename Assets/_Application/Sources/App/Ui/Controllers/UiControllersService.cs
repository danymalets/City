using System.Collections.Generic;
using Sources.App.Ui.Screens.Level;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Ui.Controllers
{
    public class UiControllersService : IUiControllersService
    {
        public MainScreenController MainScreenController { get; private set; }

        private List<ScreenControllerBase> _screenControllers = new();
        
        public UiControllersService()
        {
            IUiService uiService = DiContainer.Resolve<IUiService>();

            _screenControllers.AddRange(new ScreenControllerBase[]
            {
                MainScreenController = new MainScreenController(uiService.Get<MainScreen>()),
                MainScreenController = new MainScreenController(uiService.Get<MainScreen>())
            });
        }
    }
}