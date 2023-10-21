using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;
using Sources.Services.InstantiatorServices;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.LanguagePopups
{
    public class LanguagePopupController : ScreenController
    {
        private readonly LanguagePopup _languagePopup;
        private readonly Language[] _languages;
        private readonly IGameObjectService _gameObjectService;

        public LanguagePopupController(LanguagePopup languagePopup) 
            : base(languagePopup, new DefaultPopupAnimator(languagePopup))
        {
            _languagePopup = languagePopup;
            _languages = DiContainer.Resolve<Assets>().LocalizationAssets.Languages;
            _gameObjectService = DiContainer.Resolve<IGameObjectService>();
        }

        protected override void OnPrepare()
        {
            _gameObjectService.DestroyChildren(_languagePopup.LanguageContent);
            
            foreach (Language language in _languages)
            {
                LanguageItem languageItem = _gameObjectService
                    .Instantiate(_languagePopup.LanguageItemPrefab, _languagePopup.LanguageContent);
                
            }
        }

        protected override void OnRefresh()
        {
            _languagePopup.LanguageTitle.text = Strings.Play;
        }

        protected override void OnOpen()
        {
            
        }

        protected override void OnClose()
        {
        }
    }
}