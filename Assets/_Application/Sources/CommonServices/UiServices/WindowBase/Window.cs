using System;
using Sources.CommonServices.UiServices.System;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.CommonServices.UiServices.WindowBase
{
    [RequireComponent(typeof(Canvas))]
    public abstract class Window : MonoBehaviour, IService
    {
        protected IUiService Ui;
        public event Action<Window> Opening = delegate { };
        public event Action<Window> Closed = delegate { };
        public bool IsOpened { get; private set; }
        
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

            IsOpened = true;
            
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
            IsOpened = false;
            gameObject.Disable();
            Closed(this);
        }

        protected virtual void OnClose()
        {
        }
    }
}