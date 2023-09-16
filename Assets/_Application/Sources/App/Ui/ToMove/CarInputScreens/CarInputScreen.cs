using _Application.Sources.Utils.Utils;
using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.ToMove.CarInputScreens
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