#if UNITY_EDITOR

using Sirenix.OdinInspector;
using Sources.Utils.CommonUtils.Extensions;
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

        [Button]
        private void DisableAll()
        {
            foreach (var gameScreen in GetComponentsInChildren<GameScreen>(true))
            {
                gameScreen.gameObject.Disable();
            }
        }
    }
}

#endif
