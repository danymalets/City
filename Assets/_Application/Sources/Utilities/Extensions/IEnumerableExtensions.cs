using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetRandom<T>(this IList<T> list)
        {
            if (list.Count == 0)
                throw new InvalidOperationException("No data in collection");
            
            return list[Random.Range(0, list.Count)];
        }
        
        public static T MaxBy<T, TValue>(this IEnumerable<T> enumerable, Func<T, TValue> getValue)
            where TValue : IEquatable<TValue>
        {
            if (!enumerable.Any())
                throw new InvalidOperationException("No data in collection");
            TValue maxValue = enumerable.Max(getValue);
            return enumerable.First(item => getValue(item).Equals(maxValue));
        }
        
        public static T MinBy<T, TValue>(this IEnumerable<T> enumerable, Func<T, TValue> getValue)
            where TValue : IEquatable<TValue>
        {
            if (!enumerable.Any())
                throw new InvalidOperationException("No data in collection");
            TValue minValue = enumerable.Min(getValue);
            return enumerable.First(item => getValue(item).Equals(minValue));
        }
        
        public static T GetNearestTo<T>(this IEnumerable<T> sources, 
            MonoBehaviour target)
            where T : MonoBehaviour
        {
            if (!sources.Any())
                throw new InvalidOperationException("No data in collection");
            
            return sources.MinBy(source => 
                Vector3.Distance(source.transform.position, 
                    target.transform.position));
        }
        
        public static T GetRandomWithWeights<T>(
            this IList<T> array, 
            Func<T, float> getWeight)
        {
            if (array.Count == 0)
                throw new InvalidOperationException("No data in collection");

            float sumWeight = array.Sum(getWeight);
            
            if (Mathf.Approximately(sumWeight, 0))
                throw new InvalidOperationException("Sum weight = 0");
            
            float randValue = Random.Range(0, sumWeight);

            for (int i = 1; i < array.Count; i++)
            {
                T element = array[i];
                float weight = getWeight(element);

                if (randValue < weight)
                    return element;
                
                randValue -= weight;
            }

            return array[0];
        }

        public static bool NoOne<T>(this IEnumerable<T> enumerable) =>
            !enumerable.Any();

        public static bool NoOne<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate) =>
            !enumerable.Any(predicate);
    }
}