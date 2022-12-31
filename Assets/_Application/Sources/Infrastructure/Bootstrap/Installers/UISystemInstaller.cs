using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.UI.System;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class UISystemInstaller : MonoServiceInstaller<UiSystem, ICloseableUIService>
    {
        public UISystemInstaller(Transform parent) : base(parent)
        {
        }

        protected override void Setup(UiSystem implementation)
        {
            implementation.Setup();
        }
    }
}