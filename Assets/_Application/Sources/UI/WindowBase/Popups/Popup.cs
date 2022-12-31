using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.ApplicationCycle;
using Sources.Infrastructure.Services.Times;
using Sources.UI.Animator;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.WindowBase.Popups
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Popup : Window
    {
        [SerializeField]
        private Button[] _closeButtons;

        private PopupAnimator _popupAnimator;
        private ITimeService _timeService;
        private IApplicationCycleService _applicationCycle;

        protected override void OnSetupInternal()
        {
            _popupAnimator = GetComponent<PopupAnimator>();
        }

        protected void OpenInternal()
        {
            _timeService = DiContainer.Resolve<ITimeService>();
            _applicationCycle = DiContainer.Resolve<IApplicationCycleService>();
            
            ForceOpen(true);

            if (ShouldStopTime)
                _timeService.StopTime();
            
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
            if (ShouldStopTime)
                _timeService.ReturnTime();
            
            base.ForceClose();
        }

        private void SubscribeCloseButtons()
        {
            if (ShouldCloseOnBackButtonClicked)
                _applicationCycle.BackButtonClicked += OnCloseButtonClickedInternal;
            
            foreach (Button closeButton in _closeButtons)
                closeButton.onClick.AddListener(OnCloseButtonClickedInternal);
        }
        
        private void UnsubscribeCloseButtons()
        {
            if (ShouldCloseOnBackButtonClicked)
                _applicationCycle.BackButtonClicked -= OnCloseButtonClickedInternal;
            
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