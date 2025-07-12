using System.Threading;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.Services.ApplicationServices;
using Sources.Services.FpsServices;
using Sources.Services.TimeServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.PerformanceScreens
{
    public class PerformanceScreenController : ScreenController
    {
        
        private readonly PerformanceScreen _performanceScreen;
        private IFpsService _fpsService;
        private IApplicationService _application;
        private ITimeService _time;
        private CancellationTokenSource _cancellationTokenSource;

        public PerformanceScreenController(PerformanceScreen performanceScreen) 
            : base(performanceScreen, new ToggleAnimator(performanceScreen), true)
        {
            _performanceScreen = performanceScreen;
        }

        protected override void OnOpen()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();
            _application = DiContainer.Resolve<IApplicationService>();
            _time = DiContainer.Resolve<ITimeService>();
            
            _cancellationTokenSource = new CancellationTokenSource();
            _gameLoopService.RunEachSeconds(1, OnUpdate, true,
                _gameLoopService.CombineWithApplicationQuit(_cancellationTokenSource.Token));
        }

        private void OnUpdate()
        {
            _performanceScreen.FpsValueText.text = $"{_fpsService.FpsLastSecond:F1}";
            _performanceScreen.TargetFrameRateValueText.text = $"{_application.TargetFrameRate}";
            _performanceScreen.PhysicsUpdateCountValueText.text = $"{_time.PhysicsUpdateCount}";
        }

        protected override void OnClose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}