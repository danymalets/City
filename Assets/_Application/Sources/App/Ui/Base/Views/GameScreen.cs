using Sources.App.Ui.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Base.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class GameScreen : MonoBehaviour
    {
        [field: SerializeField] public SafeArea SafeArea { get; private set; }
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }
        [field: SerializeField] public Button[] CloseButtons { get; private set; }

        private void OnValidate()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            SafeArea = GetComponentInChildren<SafeArea>();
        }
    }
}