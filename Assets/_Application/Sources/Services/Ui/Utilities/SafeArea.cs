using Sources.Di;
using Sources.Services.Screens;
using UnityEngine;

namespace Sources.App.Game.UI.Utilities
{
    public class SafeArea : MonoBehaviour
    {
        private IScreenService _screenService;
        private RectTransform _rect;

        private void OnEnable()
        {
            _rect = GetComponent<RectTransform>();

            _screenService = DiContainer.Resolve<IScreenService>();
            
            UpdateRect();

            _screenService.ScreenResolutionChanged += OnScreenResolutionChanged;
        }

        private void OnDisable()
        {
            _screenService.ScreenResolutionChanged -= OnScreenResolutionChanged;
            _screenService = null;
        }

        private void OnScreenResolutionChanged() =>
            UpdateRect();

        private void UpdateRect()
        {
            Rect safeArea = _screenService.SafeArea;
            
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= _screenService.Width;
            anchorMin.y /= _screenService.Height;
            anchorMax.x /= _screenService.Width;
            anchorMax.y /= _screenService.Height;

            _rect.anchorMin = anchorMin;
            _rect.anchorMax = anchorMax;
        }
    }
}