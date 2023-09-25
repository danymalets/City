using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.UserServices;
using Sources.Utils.Di;

namespace Sources.Services.LocalizationServices
{
    public interface ILocalizationService : IService
    {
        Language CurrentLanguage { get; }
        StringsAsset CurrentStrings { get; }
        void ChangeLanguage(LanguageType languageType);
    }
}