using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.Vibration;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class VibrationInstaller : ServiceInstaller<VibrationService, IVibrationService>
    {
        protected override VibrationService GetService() =>
            new VibrationService();
    }
}