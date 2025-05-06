using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.AudioServices;
using Sources.Services.LocalizationServices;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sources.App.Ui.Screens.LanguagePopups.LanguageItems
{
    public class LanguageItemController
    {
        private readonly LanguageItem _languageItem;
        private readonly LanguageAsset _languageAsset;
        private readonly ILocalizationService _localizationService;
        private readonly IAudioService _audioService;

        public LanguageItemController(LanguageItem languageItem, LanguageAsset languageAsset)
        {
            _audioService = DiContainer.Resolve<IAudioService>();
            _languageItem = languageItem;
            _languageAsset = languageAsset;
            _localizationService = DiContainer.Resolve<ILocalizationService>();
        }

        public void OnCreate()
        {
            _languageItem.Image.sprite = _languageAsset.FlagSprite;
        }

        public void OnSetup()
        {
            _languageItem.Button.onClick.AddListener(LanguageItem_OnClicked);
        }

        public void OnCleanup()
        {
            _languageItem.Button.onClick.RemoveListener(LanguageItem_OnClicked);
        }

        public void OnRefresh()
        {
            _languageItem.SelectedGroup.SetActive(
                _languageAsset.LanguageType == _localizationService.CurrentLanguageAsset.LanguageType);
        }

        private void LanguageItem_OnClicked()
        {
            _audioService.PlayOnce(SoundType.ButtonClick);
            _localizationService.ChangeLanguage(_languageAsset.LanguageType);
        }
    }
}