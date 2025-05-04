using System.Collections.Generic;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class DictionaryExtensions
    {
        public static void IncreaseValue<TKey>(this Dictionary<TKey, int> dict, TKey key, int delta)
        {
            dict.TryAdd(key, 0);

            dict[key] += delta;
        }
        
        public static void IncreaseValue<TKey>(this Dictionary<TKey, long> dict, TKey key, long delta)
        {
            dict.TryAdd(key, 0);

            dict[key] += delta;
        }
    }
}