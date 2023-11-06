using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.LanguagePopups;
using Sources.App.Ui.Screens.SettingsScreens.SoundGroups;
using Sources.App.Ui.Screens.SettingsScreens.ToggleGroups;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.SettingsScreens
{
    public class SettingsPopupController : ScreenController
    {
        private readonly SettingsPopup _settingsPopup;
        private readonly SliderGroupController _soundGroupController;
        private readonly SliderGroupController _musicGroupController;
        private readonly ToggleGroupController _vibrationGroupController;
        private readonly IApplicationService _applicationService;
        private LanguagePopupController _languagePopupController;

        public SettingsPopupController(SettingsPopup settingsPopup) 
            : base(settingsPopup, new DefaultPopupAnimator(settingsPopup))
        {
            _settingsPopup = settingsPopup;

            _applicationService = DiContainer.Resolve<IApplicationService>();
            
            UserPreferences userPreferences = DiContainer.Resolve<IUserAccessService>().User.UserPreferences;
            
            _soundGroupController = new SliderGroupController(settingsPopup.SoundsSliderGroup, 
                () => userPreferences.SoundsVolume, value => userPreferences.SoundsVolume = value);
            
            _musicGroupController = new SliderGroupController(settingsPopup.MusicSliderGroup, 
                () => userPreferences.MusicVolume, value => userPreferences.MusicVolume = value);

            _vibrationGroupController = new ToggleGroupController(settingsPopup.VibrationToggleGroup, 
                () => userPreferences.IsVibrationsOn, value => userPreferences.IsVibrationsOn = value);
        }

        protected override void OnCreate()
        {
            _languagePopupController = DiContainer.Resolve<IUiControllersService>().Get<LanguagePopupController>();
        }

        protected override void OnOpen()
        {
            _soundGroupController.OnSetup();
            _musicGroupController.OnSetup();
            _vibrationGroupController.OnSetup();
            
            _settingsPopup.LanguageTextButton.Button.onClick.AddListener(LanguageTextButton_OnClicked);
            _settingsPopup.RateUsTextButton.Button.onClick.AddListener(RateUsTextButton_OnClicked);
            _settingsPopup.SupportTextButton.Button.onClick.AddListener(SupportTextButton_OnClicked);
        }

        protected override void OnClose()
        {
            _soundGroupController.OnCleanup();
            _musicGroupController.OnCleanup();
            _vibrationGroupController.OnCleanup();
        }

        protected override void OnRefresh()
        {
            _settingsPopup.SettingsTitle.text = "Settings";
            _settingsPopup.SoundsSliderGroup.Text.text = "Sounds";
            _settingsPopup.MusicSliderGroup.Text.text = "Music";
            _settingsPopup.VibrationToggleGroup.Text.text = "Vibration";
            _settingsPopup.LanguageTextButton.Text.text = "Language";
            _settingsPopup.RateUsTextButton.Text.text = "Rate Us";
            _settingsPopup.SupportTextButton.Text.text = "Support";
        }

        private void LanguageTextButton_OnClicked()
        {
            _languagePopupController.Open();
        }

        private void RateUsTextButton_OnClicked()
        {
            _applicationService.OpenUrl("https://www.google.com/");
        }

        private void SupportTextButton_OnClicked()
        {
            _applicationService.OpenUrl("https://www.google.com/");
        }
    }
}