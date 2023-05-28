using UnityEngine;

namespace Sources.App.Ui.Controllers
{
    public abstract class ScreenControllerBase
    {
        protected ScreenControllerBase(ScreenAnimator animator)
        {
        }

        internal void OnOpenInternal()
        {
            Refresh();
        }

        public void Refresh()
        {
            OnRefresh();
        }

        protected abstract void OnRefresh();
        
        public void Close()
        {
            OnClose();
        }

        protected abstract void OnClose();
    }
}