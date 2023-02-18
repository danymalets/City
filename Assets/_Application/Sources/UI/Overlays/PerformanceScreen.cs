using Sources.Data.Live;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Times;
using TMPro;
using UnityEngine;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Overlays
{
    public class PerformanceScreen : Screen
    {
        private const string FpsPattern = "Fps: {0}";
        private const string DeviceNamePattern = "Device Name: {0}";
        private const string DeviceModelPattern = "Device Model: {0}";
        private const string TargetFpsPattern = "Target Fps: {0}";
        private const string PhysicsUpdateCountPattern = "Physics Update Count: {0}";
        private const string RigidbodyCountPattern = "<b>Rigidbodies Count:</b> {0}";
        
        [SerializeField]
        private TextMeshProUGUI _fpsText;
        
        [SerializeField]
        private TextMeshProUGUI _deviceNameText;

        [SerializeField]
        private TextMeshProUGUI _deviceModelText;
        
        [SerializeField]
        private TextMeshProUGUI _targetFpsText;
        
        [SerializeField]
        private TextMeshProUGUI _physicsUpdateCountText;
        
        [SerializeField]
        private TextMeshProUGUI _rigidbodiesCountText;
        
        private IFpsService _fpsService;
        private CoroutineContext _coroutineContext;
        private IApplicationService _application;
        private ITimeService _time;

        protected override void OnOpen()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();
            _application = DiContainer.Resolve<IApplicationService>();
            _time = DiContainer.Resolve<ITimeService>();

            _coroutineContext = new CoroutineContext();
            _coroutineContext.RunEachSeconds(1, OnUpdate, true);
        }

        private void OnUpdate()
        {
            _fpsText.text = string.Format(FpsPattern, _fpsService.FpsLastSecond);
            _targetFpsText.text = string.Format(TargetFpsPattern, _application.TargetFrameRate);
            _physicsUpdateCountText.text = string.Format(PhysicsUpdateCountPattern, _time.PhysicsUpdateCount);
            _deviceNameText.text = string.Format(DeviceNamePattern, _application.DeviceName);
            _deviceModelText.text = string.Format(DeviceModelPattern, _application.DeviceModel);
            _rigidbodiesCountText.text = string.Format(RigidbodyCountPattern, FindObjectsOfType<Rigidbody>().Length);
        }

        protected override void OnClose()
        {
            _coroutineContext.StopAllCoroutines();
            _fpsService = null;
        }
    }
}