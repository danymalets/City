using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.UiUtils;
using Sources.Utils.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.CarInputScreens
{
    public class CarInputScreen : GameScreen
    {
        [field: SerializeField] public GameplayButton UpButton { get; private set; }

        [field: SerializeField] public GameplayButton DownButton { get; private set; }

        [field: SerializeField] public GameplayButton LeftButton { get; private set; }

        [field: SerializeField] public GameplayButton RightButton { get; private set; }

        [field: SerializeField] public Button ExitCarButton { get; private set; }
    }
}