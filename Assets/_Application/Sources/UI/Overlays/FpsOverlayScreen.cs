using Sources.Data.Live;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;
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
        private CoroutineContext _coroutineContext;

        protected override void OnOpen()
        {
            _fpsService = DiContainer.Resolve<IFpsService>();

            _coroutineContext = new CoroutineContext();
            _coroutineContext.RunEachSeconds(1, UpdateFps, true);
        }

        private void UpdateFps() => 
            _fpsText.text = string.Format(FpsPattern, _fpsService.FpsLastSecond.Value);

        protected override void OnClose()
        {
            _coroutineContext.StopAllCoroutines();
            _fpsService = null;
        }
    }
}