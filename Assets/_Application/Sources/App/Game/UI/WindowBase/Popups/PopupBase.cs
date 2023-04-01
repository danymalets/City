using Sources.App.Game.UI.Animator;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.ApplicationCycle;
using Sources.App.Infrastructure.Services.Times;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Game.UI.WindowBase.Popups
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PopupBase : Window
    {
        [SerializeField]
        private Button[] _closeButtons;

        [SerializeField]
        private PopupAnimator _popupAnimator;
        private ITimeService _timeService;
        private IApplicationService _application;
        
        protected void OpenInternal()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _application = DiContainer.Resolve<IApplicationService>();
            
            ForceOpen(true);

            // if (ShouldStopTime)
            //     _timeService.StopTime();
            
            if (_popupAnimator != null)
                _popupAnimator.Open(SubscribeCloseButtons);
            else
                SubscribeCloseButtons();
        }
        
        public void Close()
        {
            UnsubscribeCloseButtons();
            if (_popupAnimator != null)
                _popupAnimator.Close(ForceClose);
            else
                ForceClose();
        }

        public override void ForceClose()
        {
            // if (ShouldStopTime)
            //     _timeService.ReturnTime();
            
            base.ForceClose();
        }

        private void SubscribeCloseButtons()
        {
            if (ShouldCloseOnBackButtonClicked)
                _application.BackButtonClicked += OnCloseButtonClickedInternal;
            
            foreach (Button closeButton in _closeButtons)
                closeButton.onClick.AddListener(OnCloseButtonClickedInternal);
        }
        
        private void UnsubscribeCloseButtons()
        {
            if (ShouldCloseOnBackButtonClicked)
                _application.BackButtonClicked -= OnCloseButtonClickedInternal;
            
            foreach (Button closeButton in _closeButtons)
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

        protected virtual bool ShouldStopTime => false;
        protected virtual bool ShouldCloseOnBackButtonClicked => false;
    }
}