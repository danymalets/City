using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.App.Ui.Screens.Input
{
    public class GameplayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private int _pointers = 0;

        public bool PointerIn => _pointers > 0;
        public int PressValue => PointerIn ? 1 : 0;

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointers++;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pointers--;
        }
    }
}