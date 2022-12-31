using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            if (!enumerable.Any())
                throw new InvalidOperationException("No data in collection");
            return enumerable.ElementAt(Random.Range(0, enumerable.Count()));
        }
        
        public static T MaxBy<T, TValue>(this IEnumerable<T> enumerable, Func<T, TValue> getValue)
            where TValue : IEquatable<TValue>
        {
            if (!enumerable.Any())
                throw new InvalidOperationException("No data in collection");
            TValue maxValue = enumerable.Max(getValue);
            return enumerable.Where(item => getValue(item).Equals(maxValue)).GetRandom();
        }
        
        public static T MinBy<T, TValue>(this IEnumerable<T> enumerable, Func<T, TValue> getValue)
            where TValue : IEquatable<TValue>
        {
            if (!enumerable.Any())
                throw new InvalidOperationException("No data in collection");
            TValue minValue = enumerable.Min(getValue);
            return enumerable.Where(item => getValue(item).Equals(minValue)).GetRandom();
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
        
        public static TValue GetRandom<T, TValue>(
            this IEnumerable<T> enumerable, 
            Func<T, (float, TValue)> getValue)
        {
            if (!enumerable.Any())
                throw new InvalidOperationException("No data in collection");

            float sumWeight = enumerable.Sum(t => getValue(t).Item1);
            
            if (Mathf.Approximately(sumWeight, 0))
                throw new InvalidOperationException("Sum weight = 0");

            T[] array = enumerable.ToArray();

            float randValue = Random.Range(0, sumWeight);

            for (int i = 1; i < array.Length; i++)
            {
                T element = array[i];
                (float weight, TValue value) = getValue(element);

                if (randValue < weight)
                    return value;
                
                randValue -= weight;
            }

            return getValue(array[0]).Item2;
        }
    }
}