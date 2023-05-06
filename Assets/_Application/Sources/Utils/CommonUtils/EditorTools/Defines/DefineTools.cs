#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Sources.Utils.CommonUtils.EditorTools.Defines
{
    public class DefineTools : MonoBehaviour
    {
        [MenuItem("Project Tools/Open Define Tools")]
        private static void OpenDefineTools() => 
            AssetDatabase.OpenAsset(AssetDatabase.LoadAssetAtPath<DefineTools>(
                "Assets/_Application/Prefabs/EditorTools/DefineTools.prefab"));

        [SerializeField]
        // ReSharper disable once NotAccessedField.Local
        private DefineGroup[] _defineGroups;
    }
}

#endif