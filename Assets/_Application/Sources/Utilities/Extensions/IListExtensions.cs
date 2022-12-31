using System.Collections.Generic;
using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class IListExtensions
    {
        public static void RandomShuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int j = Random.Range(i, list.Count);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}