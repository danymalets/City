using System;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Views;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.LocalizationServices;
using Sources.Utils.Di;
using UnityEngine.UI;

namespace Sources.App.Ui.Base.Controllers
{
    public abstract class ScreenControllerBase
    {
        private readonly GameScreen _gamePopup;
        private readonly ScreenAnimator _screenAnimator;
        protected readonly CoroutineContext _coroutineContext;

        public readonly bool IsAlwaysOpen;
        private readonly ILocalizationService _localizationService;

        protected StringsAsset Strings => _localizationService.CurrentStrings;

        public bool IsOpen { get; private set; }

        public event Action<ScreenControllerBase> Opened; // Анимация открытия началась
        public event Action<ScreenControllerBase> Closed; // Анимация закрытия началась

        protected ScreenControllerBase(GameScreen gamePopup, ScreenAnimator screenAnimator, bool isAlwaysOpen)
        {
            IsAlwaysOpen = isAlwaysOpen;
            _gamePopup = gamePopup;
            _screenAnimator = screenAnimator;
            _coroutineContext = new CoroutineContext();
            _localizationService = DiContainer.Resolve<ILocalizationService>();
        }

        internal void Prepare()
        {
            OnCreate();
        }

        protected virtual void OnCreate()
        {
            
        }

        internal void OnOpenInternal()
        {
            Opened?.Invoke(this);
            _screenAnimator.PlayOpen();
            IsOpen = true;
            SubscribeCloseButtons();
            Refresh();
        }

        public void Refresh()
        {
            OnRefresh();
        }
        
        private void SubscribeCloseButtons()
        {
            foreach (Button closeButton in _gamePopup.CloseButtons)
                closeButton.onClick.AddListener(OnCloseButtonClickedInternal);
        }
        
        private void UnsubscribeCloseButtons()
        {
            foreach (Button closeButton in _gamePopup.CloseButtons)
                closeButton.onClick.RemoveListener(OnCloseButtonClickedInternal);
        }

        private void OnCloseButtonClickedInternal()
        {
            OnCloseButtonClicked();
            Close();
        }

        protected virtual void OnCloseButtonClicked()
        {
        }

        protected abstract void OnRefresh();
        
        public void Close(bool isForce = false)
        {        
            Closed?.Invoke(this);
            IsOpen = false;
            UnsubscribeCloseButtons();
            _screenAnimator.PlayClose(isForce);
            _coroutineContext.StopAllCoroutines();
            OnClose();
        }

        protected abstract void OnClose();
    }
}