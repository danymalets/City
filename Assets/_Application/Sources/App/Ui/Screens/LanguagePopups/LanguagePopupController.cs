using System.Collections.Generic;
using Sources.App.Services.AssetsServices;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.LanguagePopups.LanguageItems;
using Sources.Services.InstantiatorServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.LanguagePopups
{
    public class LanguagePopupController : ScreenController
    {
        private readonly LanguagePopup _languagePopup;
        private readonly LanguageAsset[] _languages;
        private readonly List<LanguageItemController> _languageItemControllers = new();
        private readonly IGameObjectService _gameObjectService;

        public LanguagePopupController(LanguagePopup languagePopup) 
            : base(languagePopup, new DefaultPopupAnimator(languagePopup))
        {
            _languagePopup = languagePopup;
            _languages = DiContainer.Resolve<Assets>().LocalizationAssets.Languages;
            _gameObjectService = DiContainer.Resolve<IGameObjectService>();
        }

        protected override void OnCreate()
        {
            _gameObjectService.DestroyChildren(_languagePopup.LanguageContent);
            
            foreach (LanguageAsset languageAsset in _languages)
            {
                LanguageItem languageItem = _gameObjectService
                    .Instantiate(_languagePopup.LanguageItemPrefab, _languagePopup.LanguageContent);

                LanguageItemController languageItemController = new (languageItem, languageAsset);

                languageItemController.OnCreate();
                
                _languageItemControllers.Add(languageItemController);
            }
        }

        protected override void OnOpen()
        {
            Debug.Log($"op");
            foreach (LanguageItemController languageItemController in _languageItemControllers)
            {
                Debug.Log($"op1");

                languageItemController.OnSetup();
            }
        }

        protected override void OnClose()
        {
            foreach (LanguageItemController languageItemController in _languageItemControllers)
            {
                languageItemController.OnCleanup();
            }
        }

        protected override void OnRefresh()
        {
            _languagePopup.LanguageTitle.text = Strings.Language;
            
            foreach (LanguageItemController languageItemController in _languageItemControllers)
            {
                languageItemController.OnRefresh();
            }
        }
    }
}