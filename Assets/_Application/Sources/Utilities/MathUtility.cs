namespace Sources.Utilities
{
    public static class MathUtility
    {
        public static float Sqr(float value)
            => value * value;
        
        public static int Div(float a, float b)
            => (int)(a/b);
        
        public static float Mod(float a, float b)
            => a - Div(a,b) * b;   
    }
}