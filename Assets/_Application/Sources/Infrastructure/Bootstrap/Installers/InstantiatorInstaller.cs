using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class InstantiatorInstaller : ServiceInstaller<GameObjectService, IGameObjectService>
    {
        protected override GameObjectService GetService() =>
            new GameObjectService();
    }
}