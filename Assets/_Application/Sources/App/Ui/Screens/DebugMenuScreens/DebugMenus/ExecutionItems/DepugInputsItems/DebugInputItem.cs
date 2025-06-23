namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems.DepugInputsItems
{
    public abstract class DebugInputItem
    {
        public string Title { get; }

        protected DebugInputItem(string title)
        {
            Title = title;
        }
    }
}