using Sources.Data.Live;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Fps;
using TMPro;
using UnityEngine;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Overlays
{
    public class FpsOverlayScreen : Screen
    {
        private const string FpsPattern = "FPS: {0}";
        
        [SerializeField]
        private TextMeshProUGUI _fpsText;

        private IFpsService _fpsService;

        protected override void OnOpen()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();

            UpdateFps(_fpsService.FpsLastSecond.Value);
            
            _fpsService.FpsLastSecond.Changed += UpdateFps;
        }

        private void UpdateFps(int fps) => 
            _fpsText.text = string.Format(FpsPattern, fps);

        protected override void OnClose()
        {
            _fpsService.FpsLastSecond.Changed -= UpdateFps;
            _fpsService = null;
        }
    }
}