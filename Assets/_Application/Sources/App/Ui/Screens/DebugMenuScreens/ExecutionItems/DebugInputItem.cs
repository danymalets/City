namespace Sources.App.Ui.Screens.DebugMenuScreens.ExecutionItems
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