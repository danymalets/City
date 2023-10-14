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
        private const string FpsPattern = "Fps: {0}";
        private const string DeviceNamePattern = "Device Name: {0}";
        private const string DeviceModelPattern = "Device Model: {0}";
        private const string TargetFpsPattern = "Target Fps: {0}";
        private const string PhysicsUpdateCountPattern = "Physics Update Count: {0}";
        private const string RigidbodyCountPattern = "Rigidbodies Count: {0}";
        
        private readonly PerformanceScreen _performanceScreen;
        private IFpsService _fpsService;
        private IApplicationService _application;
        private ITimeService _time;

        public PerformanceScreenController(PerformanceScreen performanceScreen) 
            : base(performanceScreen, new DefaultPopupAnimator(performanceScreen), true)
        {
            _performanceScreen = performanceScreen;
        }

        protected override void OnOpen()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();
            _application = DiContainer.Resolve<IApplicationService>();
            _time = DiContainer.Resolve<ITimeService>();

            _coroutineContext.RunEachSeconds(1, OnUpdate, true);
        }

        private void OnUpdate()
        {
            _performanceScreen.FpsText.text = string.Format(FpsPattern, $"{_fpsService.FpsLastSecond:F1}");
            _performanceScreen.InfoText.text =
                string.Join("\n", 
                    string.Format(TargetFpsPattern, _application.TargetFrameRate), 
                    string.Format(PhysicsUpdateCountPattern, _time.PhysicsUpdateCount),
                    string.Format(DeviceNamePattern, _application.DeviceName), 
                    string.Format(DeviceModelPattern, _application.DeviceModel), 
                    string.Format(RigidbodyCountPattern, GameObject.FindObjectsOfType<Rigidbody>().Length));
        }

        protected override void OnRefresh()
        {
            
        }

        protected override void OnClose()
        {
            _coroutineContext.StopAllCoroutines();
            _fpsService = null;
        }
    }
}