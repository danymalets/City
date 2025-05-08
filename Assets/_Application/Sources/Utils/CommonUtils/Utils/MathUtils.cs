using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Utils
{
    public static class MathUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Sqr(float value) => value * value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Div(float a, float b) => (int)(a/b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Mod(float x, float mod) => ((x % mod) + mod) % mod;

        #region FLOAT_COMPARE
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Equals(float a, float b) => Mathf.Abs(b - a) < Mathf.Max(1E-06f * Mathf.Max(Mathf.Abs(a), Mathf.Abs(b)), 0.00001f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool NotEquals(float a, float b) => !Equals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Greater(float a, float b) => a > b && NotEquals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Less(float a, float b) => a < b && NotEquals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool GreaterOrEquals(float a, float b) => a > b || Equals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool LessOrEquals(float a, float b) => a < b || Equals(a, b);

        #endregion

        #region DOUBLE_COMPARE

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Equals(double a, double b) => Math.Abs(b - a) < Math.Max(1E-12d * Math.Max(Math.Abs(a), Math.Abs(b)), double.Epsilon * 64d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool NotEquals(double a, double b) => !Equals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Greater(double a, double b) => a > b && NotEquals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Less(double a, double b) => a < b && NotEquals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool GreaterOrEquals(double a, double b) => a > b || Equals(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool LessOrEquals(double a, double b) => a < b || Equals(a, b);
        
        #endregion DOUBLE_COMPARE

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Equals(Rect a, Rect b) => Equals(a.x, b.x) && Equals(a.y, b.y) && Equals(a.height, b.height) && Equals(a.width, b.width);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool NotEquals(Rect a, Rect b) => !Equals(a, b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Min(params float[] values) => values.Aggregate(float.PositiveInfinity, Mathf.Min);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Max(params float[] values) => values.Aggregate(float.NegativeInfinity, Mathf.Max);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Mod(int x, int mod) => ((x % mod) + mod) % mod;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(float a, float b) => Mathf.Abs(a - b);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static float DistanceAngle(float a, float b)
        {
            float distance = PositiveAngle(a,b);
            return Mathf.Min(distance, 360-distance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static float PositiveAngle(float from, float to) => 
            Mod(to - from, 360f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static float SignedNearestAngle(float from, float to)
        {
            float positiveAngle = PositiveAngle(from, to);
            return Greater(positiveAngle, 180f) ? positiveAngle - 360f : positiveAngle;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static bool InEllipse(Vector2 point, Vector2 size) => 
            Sqr(point.x / size.x) + Sqr(point.y / size.y) <= 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static void Divide(float a, float b, Action<float> runner)
        {
            while (Greater(a, 0))
            {
                runner?.Invoke(Mathf.Min(a, b));
                a -= b;
            }
        }
    }
}