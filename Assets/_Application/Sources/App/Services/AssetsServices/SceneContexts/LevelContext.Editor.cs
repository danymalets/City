using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Props;
using TriInspector;

namespace Sources.App.Services.AssetsServices.SceneContexts
{
    public partial class LevelSceneContext
    {
        [Button("Force Validate")]
        private void OnValidate()
        {
            _props = FindObjectsOfType<PropsMonoEntity>();
        }
    }
}