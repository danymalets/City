using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class RectTransformExtensions
    {
        public static void SetMinMaxAnchors(this RectTransform rect, Vector2 minAnchor, Vector2 maxAnchor)
        {
            rect.anchorMin = minAnchor;
            rect.anchorMax = maxAnchor;
        }
    }
}