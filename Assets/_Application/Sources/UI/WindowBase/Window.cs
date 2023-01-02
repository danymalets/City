using System;
using Sources.Infrastructure.Services;
using Sources.UI.System;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.UI.WindowBase
{
    [RequireComponent(typeof(Canvas))]
    public abstract class Window : MonoBehaviour, IService
    {
        protected IUiService Ui;
        public event Action<Window> Opening = delegate { };
        public event Action<Window> Closed = delegate { };

        public void SetupInternal(IUiService ui)
        {
            Ui = ui;
            OnSetup();
        }

        protected virtual void OnSetup()
        {
        }

        protected void ForceOpen(bool makeTop)
        {
            if (makeTop)
                transform.SetAsLastSibling();
            
            Opening(this);
            gameObject.Enable();
        }

        public void Refresh() => 
            OnRefresh();

        protected virtual void OnRefresh()
        {
        }

        public virtual void ForceClose()
        {
            OnClose();
            gameObject.Disable();
            Closed(this);
        }

        protected virtual void OnClose()
        {
        }
    }
}