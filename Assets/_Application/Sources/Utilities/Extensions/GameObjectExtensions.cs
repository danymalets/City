using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool HasComponent<T>(this GameObject gameObject) =>
            gameObject.GetComponent<T>() != null;
        public static void Enable(this GameObject gameObject) => 
            gameObject.SetActive(true);
        public static void Disable(this GameObject gameObject) => 
            gameObject.SetActive(false);
    }
}