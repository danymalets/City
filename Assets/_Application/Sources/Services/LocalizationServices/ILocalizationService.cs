using System;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Utils.Di;

namespace Sources.Services.LocalizationServices
{
    public interface ILocalizationService : IService
    {
        Language CurrentLanguage { get; }
        StringsAsset CurrentStrings { get; }
        event Action LocalizationChanged;
        void ChangeLanguage(LanguageType languageType);
    }
}