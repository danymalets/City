using System;
using System.Linq;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Services.ApplicationServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.LocalizationServices
{
    public class LocalizationService : IInitializable, ILocalizationService
    {
        private readonly IApplicationService _applicationService;
        private readonly IUserAccessService _userAccessService;
        private readonly LocalizationAssets _localizationAssets;

        public Language CurrentLanguage { get; private set; }
        public StringsAsset CurrentStrings => CurrentLanguage.Strings;
        public event Action LocalizationChanged;

        public LocalizationService()
        {
            _applicationService = DiContainer.Resolve<IApplicationService>();
            _userAccessService = DiContainer.Resolve<IUserAccessService>();
            _localizationAssets = DiContainer.Resolve<Assets>().LocalizationAssets;
        }

        public void Initialize()
        {
            CurrentLanguage = GetLanguage(GetLanguageType());
        }

        private Language GetLanguage(LanguageType languageType)
        {
            if (languageType == _localizationAssets.DefaultLanguage.Type)
            {
                return _localizationAssets.DefaultLanguage;
            }
            else
            {
                return _localizationAssets.Languages.First(la => la.Type == languageType);
            }
        }

        public void ChangeLanguage(LanguageType languageType)
        {
            _userAccessService.User.Preferences.SelectedLanguage = languageType;
            CurrentLanguage = GetLanguage(languageType);
            LocalizationChanged?.Invoke();
        }

        private LanguageType GetLanguageType()
        {
            LanguageType? selectedLanguage = _userAccessService.User.Preferences.SelectedLanguage;
            
            if (selectedLanguage.TryGetValue(out LanguageType language))
            {
                return language;
            }
            else
            {
                return FindLanguageType(_applicationService.SystemLanguage);
            }
        }

        private LanguageType FindLanguageType(SystemLanguage appSystemLanguage)
        {
            foreach (Language language in _localizationAssets.Languages)
            {
                if (language.SystemLanguages.Any(systemLanguage => systemLanguage == appSystemLanguage))
                {
                    return language.Type;
                }
            }

            return _localizationAssets.DefaultLanguage.Type;
        }
    }
}