using System.Collections.Generic;
using System.Linq;
using _Application.Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool HasComponent<T>(this GameObject gameObject)
            where T : Component =>
            gameObject.GetComponent<T>() != null;
        
        public static void Enable(this GameObject gameObject) => 
            gameObject.SetActive(true);
        public static void Disable(this GameObject gameObject) => 
            gameObject.SetActive(false);
        
        public static Bounds GetAllChildMeshesBounds(this GameObject gameObject)
        {
            IEnumerable<Bounds> allBounds = gameObject
                .GetComponentsInChildren<MeshRenderer>().Select(mr => mr.bounds);
            
            Bounds bound = DBounds.CombineBounds(allBounds);
            return bound;
        }
    }
}