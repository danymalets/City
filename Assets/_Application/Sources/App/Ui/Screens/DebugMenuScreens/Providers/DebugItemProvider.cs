using Sources.App.Ui.Screens.DebugMenuScreens.ExecutionItems;

namespace Sources.App.Ui.Screens.DebugMenuScreens.Providers
{
    public abstract class DebugItemProvider
    {
        public abstract DebugExecutorItem GetItem();
    }
}