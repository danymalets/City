using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.Times;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class TimeInstaller : ServiceInstaller<TimeService, ITimeService>
    {
        protected override TimeService GetService() =>
            new TimeService();
    }
}