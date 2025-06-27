using Cysharp.Threading.Tasks;
using Sources.App.Services.GameRunnerServices;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems.DepugInputsItems;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.DebugItemProviders
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