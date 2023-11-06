using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Common;
using Sources.App.Ui.Screens.SettingsScreens.SoundGroups;
using TMPro;
using UnityEngine;
using ToggleGroup = Sources.App.Ui.Screens.SettingsScreens.ToggleGroups.ToggleGroup;

namespace Sources.App.Ui.Screens.SettingsScreens
{
    public class SettingsPopup : GamePopup
    {
        [field: SerializeField] public TextMeshProUGUI SettingsTitle { get; private set; }
        [field: SerializeField] public TextButton LanguageTextButton { get; private set; }
        [field: SerializeField] public TextButton RateUsTextButton { get; private set; }
        [field: SerializeField] public TextButton SupportTextButton { get; private set; }
        [field: SerializeField] public SliderGroup SoundsSliderGroup { get; private set; }
        [field: SerializeField] public SliderGroup MusicSliderGroup { get; private set; }
        [field: SerializeField] public ToggleGroup VibrationToggleGroup { get; private set; }
    }
}