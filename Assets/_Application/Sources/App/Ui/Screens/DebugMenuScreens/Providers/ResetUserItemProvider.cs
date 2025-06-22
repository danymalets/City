using Cysharp.Threading.Tasks;
using Sources.App.Services.GameReloadServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using TMPro;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.Providers
{
    public class ResetUserItemProvider : DebugItemProvider
    {
        private readonly IUserResetService _userAccessService;
        private readonly IApplicationService _applicationService;

        public ResetUserItemProvider()
        {
            _userAccessService = DiContainer.Resolve<IUserResetService>();
            _applicationService = DiContainer.Resolve<IApplicationService>();
        }

        public override DebugExecutorItem GetItem()
        {
            return new DebugExecutorItem($"Reset User",
                new DebugInputItem[] { }, (input) =>
                {
                    if (DiContainer.TryResolve(out IGameReloadService gameReloadService))
                    {
                        _userAccessService.Reset();
                        gameReloadService.ReloadGame();
                        return UniTask.FromResult(new DebugExecutorResult(DebugResultStatus.Success));
                    }
                    else
                    {
                        return UniTask.FromResult(new DebugExecutorResult(DebugResultStatus.Failure,
                            $"Not in main ui state"));
                    }
                });
        }
    }
}