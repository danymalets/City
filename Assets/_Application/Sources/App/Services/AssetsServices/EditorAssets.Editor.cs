#if UNITY_EDITOR

using UnityEditor;

namespace Sources.App.Services.AssetsServices
{
    internal static class EditorAssetsAccess
    {
        private const string AssetsPath = "Assets/_Application/Assets/Assets.asset";
        
        public static Assets Assets =>
            AssetDatabase.LoadAssetAtPath<Assets>(AssetsPath);
    }
}

#endif