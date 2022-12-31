using UnityEngine;

namespace Sources.Utilities
{
    public static class CustomColorUtility
    {
        public static float Distance(Color a, Color b) => 
            Vector4.Distance(a, b);

        public static Color MoveTowards(Color source, Color target, float maxDistance) =>
            Vector4.MoveTowards(source, target, maxDistance);
    }
}