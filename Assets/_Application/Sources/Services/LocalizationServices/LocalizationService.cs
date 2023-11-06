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
        private readonly LocalizationAssets _localizationAssets;
        private readonly UserPreferences _userPreferences;

        public LanguageAsset CurrentLanguageAsset { get; private set; }
        public StringsAsset CurrentStrings => CurrentLanguageAsset.Strings;
        public event Action LocalizationChanged;

        public LocalizationService()
        {
            _applicationService = DiContainer.Resolve<IApplicationService>();
            _userPreferences = DiContainer.Resolve<IUserAccessService>().User.UserPreferences;
            _localizationAssets = DiContainer.Resolve<Assets>().LocalizationAssets;
        }

        public void Initialize()
        {
            CurrentLanguageAsset = GetLanguage(GetLanguageType());
        }

        private LanguageAsset GetLanguage(LanguageType languageType) => 
            _localizationAssets.Languages.First(la => la.LanguageType == languageType);

        public void ChangeLanguage(LanguageType languageType)
        {
            _userPreferences.SelectedLanguage = languageType;
            CurrentLanguageAsset = GetLanguage(languageType);
            LocalizationChanged?.Invoke();
        }

        private LanguageType GetLanguageType()
        {
            if (_userPreferences.SelectedLanguage.TryGetValue(out LanguageType language))
            {
                return language;
            }
            else
            {
                return FindLanguageType(_applicationService.SystemLanguage);
            }
        }

        private LanguageType FindLanguageType(SystemLanguage systemLanguage)
        {
            if (_localizationAssets.Languages.TryGetFirst(
                    l => l.SystemLanguages.Any(sl => sl == systemLanguage),
                    out LanguageAsset languageAsset))
            {
                return languageAsset.LanguageType;
            }
            else
            {
                return _localizationAssets.Languages.First(l => l.IsDefaultLanguage).LanguageType;
            }
        }
    }
}