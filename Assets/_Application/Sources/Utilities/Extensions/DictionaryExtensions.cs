using System.Collections.Generic;

namespace Sources.Utilities.Extensions
{
    public static class DictionaryExtensions
    {
        public static void IncreaseValue<TKey>(this Dictionary<TKey, int> dict, TKey key, int delta)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key,0);

            dict[key] += delta;
        }
        
        public static void IncreaseValue<TKey>(this Dictionary<TKey, long> dict, TKey key, long delta)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key,0);

            dict[key] += delta;
        }
    }
}