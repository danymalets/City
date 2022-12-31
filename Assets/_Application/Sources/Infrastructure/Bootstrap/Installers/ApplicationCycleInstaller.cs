using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.ApplicationCycle;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class ApplicationCycleInstaller :
        MonoServiceInstaller<ApplicationCycleService, IApplicationCycleService>
    {
        public ApplicationCycleInstaller(Transform parent) : base(parent)
        {
        }
    }
}