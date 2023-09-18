using System;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.AdsServices
{
    public class IronSourceAdapter
    {
        private const string AppKey = "1babbeefd";

        private readonly IApplicationService _applicationService;
        private Action _onSuccess;
        private Action _onFailed;

        public IronSourceAdapter()
        {
            _applicationService = DiContainer.Resolve<IApplicationService>();
        }
        
        public void Initialize()
        {
            _applicationService.PauseStatusChanged += ApplicationService_OnPauseStatusChanged;

            IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
            IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
            IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
            IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
            IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

            IronSource.Agent.init(AppKey, IronSourceAdUnits.REWARDED_VIDEO);
            
            Debug.Log($"[IronSource] StartInitialize");
        }

        public bool IsRewardedAvailable() =>
            IronSource.Agent.isRewardedVideoAvailable();

        public void ShowRewarded(Action onSuccess, Action onFailed)
        {
            _onSuccess = onSuccess;
            _onFailed = onFailed;
            
            Debug.Log($"[IronSource] ShowRewarded IsRewardedAvailable:{IsRewardedAvailable()}");

            if (IsRewardedAvailable())
            {
                IronSource.Agent.showRewardedVideo();
            }
            else
            {
                InvokeFailed();
            }
        }

        private void SdkInitializationCompletedEvent()
        {
            Debug.Log($"[IronSource] SdkInitializationCompletedEvent");
        }

        private void ApplicationService_OnPauseStatusChanged(bool isPaused)
        {
            IronSource.Agent.onApplicationPause(isPaused);
        }
        
        private void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdAvailable");
        }

        private void RewardedVideoOnAdUnavailable()
        {
            Debug.Log($"[IronSource] RewardedVideoOnAdUnavailable");
        }

        private void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] RewardedVideoOnAdOpenedEvent");
        }

        private void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] RewardedVideoOnAdClosedEvent");
            InvokeFailed();
        }
        
        private void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] RewardedVideoOnAdRewardedEvent");

            InvokeSuccess();
        }

        private void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] RewardedVideoOnAdShowFailedEvent");

            InvokeFailed();
        }
        
        private void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] RewardedVideoOnAdClickedEvent");
        }
        
        private void InvokeSuccess()
        {
            _onSuccess?.Invoke();
            _onSuccess = null;
            _onFailed = null;
        }

        private void InvokeFailed()
        {
            _onFailed?.Invoke();
            _onSuccess = null;
            _onFailed = null;
        }
    }
}