using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static bool HasComponent<T>(this Component monoBehaviour) 
            where T : Component =>
            monoBehaviour.gameObject.HasComponent<T>();
    }
}