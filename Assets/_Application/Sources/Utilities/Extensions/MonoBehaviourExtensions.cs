using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static bool HasComponent<T>(this Component monoBehaviour) 
            where T : Component =>
            monoBehaviour.gameObject.HasComponent<T>();
    }
}