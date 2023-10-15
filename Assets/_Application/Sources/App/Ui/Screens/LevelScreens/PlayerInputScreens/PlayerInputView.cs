using Sources.App.Ui.Base.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens
{
    public class PlayerInputView : GameScreen
    {
        [field: SerializeField] public Joystick Joystick { get; private set; }
        [field: SerializeField] public Button EnterCarButton { get; private set; }
        [field: SerializeField] public Button JumpButton { get; private set; }
    }
}