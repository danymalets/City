using Sources.App.Ui.Base.Views;
using Sources.Utils.UiUtils;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LevelScreens.CarInputScreens
{
    public class CarInputView : GameScreen
    {
        [field: SerializeField] public GameplayButton UpButton { get; private set; }

        [field: SerializeField] public GameplayButton DownButton { get; private set; }

        [field: SerializeField] public GameplayButton LeftButton { get; private set; }

        [field: SerializeField] public GameplayButton RightButton { get; private set; }

        [field: SerializeField] public Button ExitCarButton { get; private set; }
    }
}