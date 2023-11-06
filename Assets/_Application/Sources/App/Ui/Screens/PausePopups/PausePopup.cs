using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.PausePopups
{
    public class PausePopup : GamePopup
    {
        [field: SerializeField] public TextMeshProUGUI Title { get; private set; }
        [field: SerializeField] public TextButton SettingsButton { get; private set; }
        [field: SerializeField] public TextButton ContinueButton { get; private set; }
        [field: SerializeField] public TextButton RestartButton { get; private set; }
        [field: SerializeField] public TextButton ExitButton { get; private set; }
    }
}