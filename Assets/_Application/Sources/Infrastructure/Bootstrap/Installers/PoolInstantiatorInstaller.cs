using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.Pool.Instantiators;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class PoolInstantiatorInstaller : 
        ServiceInstaller<PoolInstantiatorService, IPoolInstantiatorService>
    {
        protected override PoolInstantiatorService GetService() =>
            new PoolInstantiatorService();
    }
}