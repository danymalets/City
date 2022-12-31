namespace Sources.UI.WindowBase.Screens
{
    public abstract class Screen : Window
    {
        protected void OpenInternal() =>
            ForceOpen(MakeTopOnLoad);

        public void Close() =>
            ForceClose();

        protected virtual bool MakeTopOnLoad => false;
    }
}