using System;
using Cysharp.Threading.Tasks;
using Sources.App.Services.GameRunnerServices;
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
                        gameRunnerService.RunGame(new RunMatchSettings(true));
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