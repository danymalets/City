namespace Sources.App.Ui.Screens.DebugMenuScreens
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