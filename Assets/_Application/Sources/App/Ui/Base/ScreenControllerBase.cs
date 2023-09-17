using System;
using Sources.App.Ui.Base.Animators;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;
using UnityEngine.UI;

namespace Sources.App.Ui.Base
{
    public abstract class ScreenControllerBase
    {
        private readonly GameScreen _gameScreen;
        private readonly ScreenAnimator _screenAnimator;
        protected readonly CoroutineContext _coroutineContext;

        public bool IsOpen { get; private set; }

        public event Action<ScreenControllerBase> Opened; // Анимация открытия началась
        public event Action<ScreenControllerBase> Closed; // Анимация закрытия началась
        
        protected ScreenControllerBase(GameScreen gameScreen, ScreenAnimator screenAnimator)
        {
            _gameScreen = gameScreen;
            _screenAnimator = screenAnimator;
            _coroutineContext = DiContainer.Resolve<ICoroutineContextCreatorService>()
                .CreateCoroutineContext();
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