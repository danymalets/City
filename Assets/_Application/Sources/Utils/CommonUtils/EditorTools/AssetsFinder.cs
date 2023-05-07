#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Sources.Utils.CommonUtils.EditorTools
{
    public static class AssetsFinder
    {
        public static IEnumerable<T> FindAssetsByType<T>() where T : Object
        {
            string[] guids = AssetDatabase.FindAssets("", new[]{"Assets"}); // or Assets/
           
            Debug.Log(guids.Length);
            
            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                
                if (asset != null)
                {
                    yield return asset;
                }
            }
        }
    }
}

#endif
