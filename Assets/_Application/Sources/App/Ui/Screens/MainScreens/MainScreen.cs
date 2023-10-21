using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.MainScreens
{
    public class MainScreen : GameScreen
    {
        [field: SerializeField] public TextButton PlayTextButton { get; private set; }
        [field: SerializeField] public TextButton ShopTextButton { get; private set; }
        [field: SerializeField] public Button SettingsTextButton { get; private set; }
    }
}