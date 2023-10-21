using UnityEngine;

namespace Sources.App.Ui.Base.Views
{
    public abstract class GamePopup : GameScreen
    {
        [field: SerializeField] public Transform Content { get; private set; }
    }
}