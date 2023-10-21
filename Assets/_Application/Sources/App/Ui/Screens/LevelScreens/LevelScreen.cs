using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreen : GameScreen
    {
        [field: SerializeField] public Button PauseButton { get; private set; }
        [field: SerializeField] public PlayerInputView PlayerInputView { get; private set; }
        [field: SerializeField] public CarInputView CarInputView { get; private set; }
    }
}