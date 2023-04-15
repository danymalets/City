using Sources.CommonServices.ApplicationServices;
using Sources.CommonServices.CoroutineRunnerServices;
using Sources.CommonServices.FpsServices;
using Sources.CommonServices.TimeServices;
using Sources.Utils.Di;
using TMPro;
using UnityEngine;

namespace Sources.App.UI.Overlays
{
    public class PerformanceScreen : CommonServices.UiServices.WindowBase.Screens.Screen
    {
        private const string FpsPattern = "Fps: {0}";
        private const string DeviceNamePattern = "Device Name: {0}";
        private const string DeviceModelPattern = "Device Model: {0}";
        private const string TargetFpsPattern = "Target Fps: {0}";
        private const string PhysicsUpdateCountPattern = "Physics Update Count: {0}";
        private const string RigidbodyCountPattern = "Rigidbodies Count: {0}";
        
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

        [SerializeField]
        private TextMeshProUGUI _perfText;
        
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

        public void SetInfoText(string text)
        {
            _perfText.text = text;
        }

        protected override void OnClose()
        {
            _coroutineContext.StopAllCoroutines();
            _fpsService = null;
        }
    }
}