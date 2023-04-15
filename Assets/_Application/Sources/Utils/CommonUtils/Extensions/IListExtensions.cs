using System.Collections.Generic;
using _Application.Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Extensions
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

        public static T ValueByCycledIndex<T>(this IList<T> list, int index) =>
            list[DMath.Mod(index, list.Count)];
    }
}