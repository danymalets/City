namespace Sources.Utilities.Extensions
{
    public static class FloatExtensions
    {
        public static bool InRange(this float value, float min, float max) =>
            value >= min && value <= max;
    }
}