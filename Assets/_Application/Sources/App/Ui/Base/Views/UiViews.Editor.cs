#if UNITY_EDITOR

using UnityEditor;

namespace Sources.App.Ui.Base.Views
{
    public partial class UiViews
    {
        [MenuItem("Project Tools/Open Ui Views")]
        private static void OpenDefineTools() => 
            AssetDatabase.OpenAsset(AssetDatabase.LoadAssetAtPath<UiViews>(
                "Assets/_Application/Prefabs/UI/UiViews.prefab"));
        
        private void OnValidate()
        {
            GameScreens = GetComponentsInChildren<GameScreen>(true);
        }
    }
}

#endif
