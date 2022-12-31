using Sources.Infrastructure.Services;

namespace Sources.Infrastructure.Bootstrap.InstallersBase
{
    public abstract class ServiceInstaller<TImplementation, TService> : Installer
        where TImplementation : class, TService
        where TService : class, IService
    {
        public override void InstallBindings()
        {
            TImplementation implementation = GetService();
            Setup(implementation);
            DiContainer.Register<TService>(implementation);
        }

        protected abstract TImplementation GetService();

        protected virtual void Setup(TImplementation implementation)
        {
        }
    }
}