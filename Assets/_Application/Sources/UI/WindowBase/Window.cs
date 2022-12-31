using System;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.UI.WindowBase
{
    [RequireComponent(typeof(Canvas))]
    public abstract class Window : MonoBehaviour
    {
        public event Action<Window> Opening = delegate { };
        public event Action<Window> Closed = delegate { };

        public void SetupInternal()
        {
            OnSetupInternal();
            OnSetup();
        }

        protected virtual void OnSetupInternal()
        {
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