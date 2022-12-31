namespace Sources.UI.WindowBase.Popups
{
    public abstract class SimplePopup : Popup, ISimpleWindow
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