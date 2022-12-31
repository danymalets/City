using Sources.Infrastructure.Bootstrap.InstallersBase;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class FPSInstaller : Installer
    {
        public override void InstallBindings()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }
    }
}