using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static bool HasComponent<T>(this Component monoBehaviour) 
            where T : Component =>
            monoBehaviour.gameObject.HasComponent<T>();
    }
}