using System.Collections.Generic;
using System.Linq;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool HasComponent<T>(this GameObject gameObject) =>
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

        public static void SetLayerRecursive(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform transform in gameObject.transform)
            {
                transform.gameObject.SetLayerRecursive(layer);
            }
        }
    }
}