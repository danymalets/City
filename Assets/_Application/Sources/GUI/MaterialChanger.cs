using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Sources.GUI
{
    public static class MaterialChanger
    {
#if UNITY_EDITOR

        [MenuItem("Auto/Change Materials")]
        private static void Change()
        {
            var materials = FindAssetsByType<Material>();

            Debug.Log(materials.Count);
            
            Shader s = null;

            foreach (Material material in materials)
            {
                //material.SetColor("_Color", material.GetColor("_BaseColor"));
                
                if (material.shader.name == "Standard")
                    s = material.shader;
            }

            if (s != null)
            {
                Debug.Log("no bug");
                foreach (Material material in materials)
                {
                    material.shader = s;
                }
            }
            else
            {
                Debug.Log("bug");
            }
        }

        public static List<T> FindAssetsByType<T>() where T : UnityEngine.Object
        {
            List<T> assets = new List<T>();
            string[] guids = AssetDatabase.FindAssets("", new[]{"Assets/Ref"});
            Debug.Log(guids.Length);
            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                if (asset != null)
                {
                    assets.Add(asset);
                }
            }

            return assets;
        }

#endif
    }
}