using Sources.Services.UiServices.WindowBase.Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.MainScreens
{
    public class MainScreen : GameScreen
    {
        [field : SerializeField] public Button PlayButton { get; private set; }
        [field : SerializeField] public TextMeshProUGUI PlayButtonText { get; private set; }
    }
}