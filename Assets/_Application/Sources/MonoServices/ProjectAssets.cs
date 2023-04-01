using Sources.App;
using UnityEditor;

namespace Sources.ProjectEditor
{
    public class ProjectAssets
    {
        public const string MonoServicesPath = "Assets/_Application/Prefabs/Services/MonoServices.prefab";
        
        public static MonoServices EditorServices =>
            AssetDatabase.LoadAssetAtPath<MonoServices>(MonoServicesPath);
    }
}