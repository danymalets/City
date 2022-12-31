using System.Collections.Generic;

namespace Sources.Infrastructure.Bootstrap.InstallersBase
{
    public abstract class Installer
    {
        public abstract void InstallBindings();

        public static void InstallBindings(IEnumerable<Installer> installers)
        {
            foreach (Installer installer in installers)
                installer.InstallBindings();
        }
    }
}