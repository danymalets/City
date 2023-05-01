using Sources.Services.ApplicationServices;
using Sources.Services.TimeServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Services.UiServices.WindowBase.Popups
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