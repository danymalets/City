using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.Utils.UiUtils
{
    public class GameplayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsPressing { get; private set; }
        public int PressValue => IsPressing ? 1 : 0;

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressing = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressing = false;
        }

        private void OnDisable()
        {
            IsPressing = false;
        }
    }
}