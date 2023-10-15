using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.PausePopups
{
    public class PausePopup : GameScreen
    {
        [field: SerializeField] public TextButton SettingsButton { get; private set; }
        [field: SerializeField] public TextButton ExitButton { get; private set; }
        [field: SerializeField] public TextButton RestartButton { get; private set; }
    }
}