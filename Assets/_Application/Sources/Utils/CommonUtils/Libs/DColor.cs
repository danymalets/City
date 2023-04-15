using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Libs
{
    public static class DColor
    {
        public static Color Red = From256(255, 0, 0);
        public static Color Yellow = From256(255, 255, 0);
        public static Color Orange = From256(255, 128, 0);
        public static Color Blue = From256(0, 0, 255);
        public static Color Purple = From256(128, 0, 128);
        public static Color Pink = From256(255, 192, 203);
        public static Color SkyBlue = From256(135, 206, 235);
        public static Color Green = From256(0, 255, 0);
        public static Color Brown = From256(128, 64, 0);
        public static Color White = From256(255, 255, 255);
        public static Color Black = From256(0, 0, 0);
        public static Color Grey = From256(128, 128, 128);
        
        public static Color[] MainColors =
        {
            Red, Yellow, Orange, Blue, Purple, Pink, SkyBlue, Green, Brown, White, Black, Grey
        };


        public static Color From256(int r, int g, int b, int a = 255) =>
            new Color32((byte)r, (byte)g, (byte)b, (byte)a);

        public static float Distance(Color a, Color b) =>
            Vector4.Distance(a, b);

        public static Color MoveTowards(Color source, Color target, float maxDistance) =>
            Vector4.MoveTowards(source, target, maxDistance);
    }
}