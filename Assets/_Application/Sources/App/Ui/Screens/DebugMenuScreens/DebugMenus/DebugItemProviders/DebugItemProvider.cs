using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.DebugItemProviders
{
    public abstract class DebugItemProvider
    {
        public abstract DebugExecutorItem GetItem();
    }
}