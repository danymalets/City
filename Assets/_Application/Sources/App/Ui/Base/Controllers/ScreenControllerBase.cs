using System;
using System.Threading;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Views;
using Sources.Services.LocalizationServices;
using Sources.Services.ScreenServices;
using Sources.Services.UpdateLoopServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Base.Controllers
{
    public abstract class ScreenControllerBase
    {
        private readonly GameScreen _gameScreen;
        private readonly ScreenAnimator _screenAnimator;

        public readonly bool IsAlwaysOpen;
        private readonly ILocalizationService _localizationService;
        protected readonly IAudioService _audioService;
        protected readonly IUpdateLoopService UpdateLoopService;
        private readonly IScreenService _screenService;

        protected StringsAsset Strings => _localizationService.CurrentStrings;

        public bool IsOpen { get; private set; }

        public event Action<ScreenControllerBase> Opened; // Animation "Open" started
        public event Action<ScreenControllerBase> Closed; // Animation "Close" started

        protected ScreenControllerBase(GameScreen gameScreen, ScreenAnimator screenAnimator, bool isAlwaysOpen)
        {
            IsAlwaysOpen = isAlwaysOpen;
            _gameScreen = gameScreen;
            _screenAnimator = screenAnimator;
            UpdateLoopService = DiContainer.Resolve<IUpdateLoopService>();
            
            _screenService = DiContainer.Resolve<IScreenService>();
            _localizationService = DiContainer.Resolve<ILocalizationService>();
            _audioService = DiContainer.Resolve<IAudioService>();
        }

        internal void Create()
        {
            OnCreate();
        }

        protected virtual void OnCreate() { }

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
            if (_gameScreen.SafeArea != null)
            {
                (Vector2 minAnchor, Vector2 maxAnchor) = _screenService.GetSafeAreaMinMaxAnchors();
                _gameScreen.SafeArea.RectTransform.SetMinMaxAnchors(minAnchor, maxAnchor);
            }
            OnRefresh();
        } 

        private void SubscribeCloseButtons()
        {
            foreach (Button closeButton in _gameScreen.CloseButtons)
                closeButton.onClick.AddListener(OnCloseButtonClickedInternal);
        }
        
        private void UnsubscribeCloseButtons()
        {
            foreach (Button closeButton in _gameScreen.CloseButtons)
                closeButton.onClick.RemoveListener(OnCloseButtonClickedInternal);
        }

        private void OnCloseButtonClickedInternal()
        {
            _audioService.PlayOnce(SoundType.ButtonClick);
            OnCloseButtonClicked();
            Close();
        }

        protected virtual void OnCloseButtonClicked() { }

        protected virtual void OnRefresh() { }

        public void Close(bool isForce = false)
        {        
            Closed?.Invoke(this);
            IsOpen = false;
            UnsubscribeCloseButtons();
            _screenAnimator.PlayClose(isForce);
            OnClose();
        }

        protected abstract void OnClose();
    }
}