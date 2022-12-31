using UnityEngine;

namespace Sources.Utilities.Extensions
{    
    public static class SerializationExtensions
    {
        public static T ToDeserialized<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
        
        public static string ToJson<T>(this T obj) => 
            JsonUtility.ToJson(obj);
    }
}