using UnityEngine;

namespace Sources.UI.Utilities
{
    public class SaveArea : MonoBehaviour
    {
        private int _screenWidth;
        private int _screenHeight;
        private Rect _safeArea;
        private RectTransform _rect;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            UpdateRect();
        }

        private void Update()
        {
            if (ShouldUpdateRect())
                UpdateRect();
        }

        private void UpdateRect()
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
            _safeArea = Screen.safeArea;
            
            Rect safeArea = Screen.safeArea;
            
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _rect.anchorMin = anchorMin;
            _rect.anchorMax = anchorMax;
        }

        private bool ShouldUpdateRect() =>
            _screenWidth != Screen.width ||
            _screenHeight != Screen.height ||
            _safeArea != Screen.safeArea;
    }
}