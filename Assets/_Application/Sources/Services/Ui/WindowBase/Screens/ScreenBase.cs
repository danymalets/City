namespace Sources.Services.Ui.WindowBase.Screens
{
    public abstract class ScreenBase : Window
    {
        protected void OpenInternal() =>
            ForceOpen(MakeTopOnLoad);

        public void Close() =>
            ForceClose();

        protected virtual bool MakeTopOnLoad => false;
    }
}