using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.AssetsManager;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class AssetsInstaller : MonoServiceInstaller<AssetsService, IAssetsService>
    {
        public AssetsInstaller(Transform parent) : base(parent)
        {
        }
    }
}