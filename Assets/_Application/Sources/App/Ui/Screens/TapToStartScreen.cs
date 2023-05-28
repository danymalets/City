using System;
using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine.EventSystems;

namespace Sources.App.Ui.Screens
{
    public class TapToStartScreen : GameScreen, IEndDragHandler, IPointerClickHandler
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