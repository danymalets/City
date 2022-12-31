using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.CoroutineRunner;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class CoroutineRunnerInstaller : 
        MonoServiceInstaller<CoroutineRunnerService, ICoroutineRunnerService>
    {
        public CoroutineRunnerInstaller(Transform parent) : base(parent)
        {
        }
    }
}