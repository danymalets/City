using System;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class NullableExtensions
    {
        public static bool TryGetValue<T>(this T? nullable, out T value)
            where T : struct
        {
            if (nullable.HasValue)
            {
                value = nullable.Value;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    }
}