using System;
using Sources.UI.WindowBase.Screens;
using UnityEngine.EventSystems;

namespace Sources.UI.Screens
{
    public class TapToStartScreen : Screen, IEndDragHandler, IPointerClickHandler
    {
        public event Action Tapped;


        public void OnEndDrag(PointerEventData eventData)
        {
            OnTapped();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTapped();
        }

        private void OnTapped()
        {
            Close();
            Tapped?.Invoke();
        }
    }
}