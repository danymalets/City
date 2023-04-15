using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class ColorExtensions
    {
        public static Color WithAlpha(this Color color, float alpha) => 
            new(color.r, color.g, color.b, alpha);
    }
}