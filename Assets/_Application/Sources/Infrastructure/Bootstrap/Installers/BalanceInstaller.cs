using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class BalanceInstaller : ServiceInstaller<BalanceService, IBalanceService>
    {
        protected override BalanceService GetService() =>
            new BalanceService();

        protected override void Setup(BalanceService balance)
        {
            balance.Load();
        }
    }
}