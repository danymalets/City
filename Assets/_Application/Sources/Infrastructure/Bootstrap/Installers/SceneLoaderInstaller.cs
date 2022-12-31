using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.SceneLoader;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class SceneLoaderInstaller : ServiceInstaller<SceneLoaderService, ISceneLoaderService>
    {
        protected override SceneLoaderService GetService() =>
            new SceneLoaderService();
    }
}