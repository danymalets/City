using System;
using System.Threading;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Views;
using Sources.Services.GameLoopServices;
using Sources.Services.LocalizationServices;
using Sources.Utils.Di;
using UnityEngine.UI;

namespace Sources.App.Ui.Base.Controllers
{
    public abstract class ScreenControllerBase
    {
        private readonly GameScreen _gamePopup;
        private readonly ScreenAnimator _screenAnimator;

        public readonly bool IsAlwaysOpen;
        private readonly ILocalizationService _localizationService;
        protected readonly IAudioService _audioService;
        protected readonly IGameLoopService _gameLoopService;
        private readonly CancellationTokenSource _gameLoopCancellationTokenSource;
        protected readonly CancellationToken _gameLoopCancellationToken;

        protected StringsAsset Strings => _localizationService.CurrentStrings;

        public bool IsOpen { get; private set; }

        public event Action<ScreenControllerBase> Opened; // Анимация открытия началась
        public event Action<ScreenControllerBase> Closed; // Анимация закрытия началась

        protected ScreenControllerBase(GameScreen gamePopup, ScreenAnimator screenAnimator, bool isAlwaysOpen)
        {
            IsAlwaysOpen = isAlwaysOpen;
            _gamePopup = gamePopup;
            _screenAnimator = screenAnimator;
            _gameLoopCancellationTokenSource = new CancellationTokenSource();
            _gameLoopCancellationToken = _gameLoopCancellationTokenSource.Token;
            _gameLoopService = DiContainer.Resolve<IGameLoopService>();

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

        public void Refresh() => OnRefresh();

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
            _gameLoopCancellationTokenSource.Cancel();
            UnsubscribeCloseButtons();
            _screenAnimator.PlayClose(isForce);
            OnClose();
        }

        protected abstract void OnClose();
    }
}