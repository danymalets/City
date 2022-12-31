using System;
using UnityEngine;

namespace Sources.UI.Animator
{
    public abstract class PopupAnimator : MonoBehaviour
    {
        public abstract void Open(Action onOpened);
        public abstract void Close(Action onClosed);
    }
}