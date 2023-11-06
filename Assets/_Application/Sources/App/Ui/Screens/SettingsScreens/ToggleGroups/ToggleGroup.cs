using Sources.App.Ui.Common.CustomToggles;
using Sources.App.Ui.Common.ToggleableImages;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.SettingsScreens.ToggleGroups
{
    public class ToggleGroup : MonoBehaviour
    {
        [field: SerializeField] public ToggleableImage ToggleableImage { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
        [field: SerializeField] public CustomToggle Toggle { get; private set; }
    }
}