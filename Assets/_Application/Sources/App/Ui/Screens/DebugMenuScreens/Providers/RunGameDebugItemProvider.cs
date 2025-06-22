using System;
using Cysharp.Threading.Tasks;
using Sources.App.Services.GameRunnerServices;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.Utils.Di;
using TMPro;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.Providers
{
    public class RunGameDebugItemProvider : DebugItemProvider
    {

        public RunGameDebugItemProvider()
        {
        }

        public override DebugExecutorItem GetItem()
        {
            return new DebugExecutorItem("Run Game",
                new DebugInputItem[] { }, (input) =>
                {
                    if (DiContainer.TryResolve(out IGameRunnerService gameRunnerService))
                    {
                        gameRunnerService.RunGame(new RunGameSettings(true));
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