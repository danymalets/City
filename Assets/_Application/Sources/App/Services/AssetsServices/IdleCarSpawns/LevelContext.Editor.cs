using System;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Props;
using TriInspector;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns
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