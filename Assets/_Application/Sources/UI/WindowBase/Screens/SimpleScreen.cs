namespace Sources.UI.WindowBase.Screens
{
    public abstract class SimpleScreen : Screen, ISimpleWindow
    {
        public void Open()
        {
            OpenInternal();
            OnOpen();
        }

        protected virtual void OnOpen()
        {
        }
    }
}