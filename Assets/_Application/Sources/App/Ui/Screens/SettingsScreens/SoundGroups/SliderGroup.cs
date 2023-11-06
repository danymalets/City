using Sources.App.Ui.Common.ToggleableImages;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.SettingsScreens.SoundGroups
{
    public class SliderGroup : MonoBehaviour
    {
        [field: SerializeField] public ToggleableImage ToggleableImage { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
        [field: SerializeField] public Slider Slider { get; private set; }
    }
}