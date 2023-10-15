using System;
using Sirenix.OdinInspector;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Props;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns
{
    public partial class LevelSceneContext
    {
        [Button("Force Validate", ButtonSizes.Large)]
        private void OnValidate()
        {
            _props = FindObjectsOfType<PropsMonoEntity>();
        }
    }
}