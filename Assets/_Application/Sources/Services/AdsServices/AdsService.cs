using System;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.AdsServices
{
    public class AdsService : IInitializable, IAdsService
    {
        private const string AppKey = "1babbeefd";

        private readonly IApplicationService _applicationService;
        private Action _onSuccess;
        private Action _onFailed;

        public AdsService()
        {
            _applicationService = DiContainer.Resolve<IApplicationService>();
        }

        public void Initialize()
        {
            _applicationService.PauseStatusChanged += ApplicationService_OnPauseStatusChanged;

            //Add AdInfo Rewarded Video Events
            IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
            IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
            IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
            IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
            IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
            
            Debug.Log($"start init");
            
            IronSource.Agent.init(AppKey);
            
            IronSource.Agent.validateIntegration();
        }

        public bool IsRewardedAvailable =>
            IronSource.Agent.isRewardedVideoAvailable();

        public void ShowRewarded(Action onSuccess, Action onFailed)
        {
            _onSuccess = onSuccess;
            _onFailed = onFailed;

            if (IsRewardedAvailable)
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
            Debug.Log($"ad init");

            IronSource.Agent.validateIntegration();
        }

        private void ApplicationService_OnPauseStatusChanged(bool isPaused)
        {
            IronSource.Agent.onApplicationPause(isPaused);
        }
        
/************* RewardedVideo AdInfo Delegates *************/
// Indicates that there’s an available ad.
// The adInfo object includes information about the ad that was loaded successfully
// This replaces the RewardedVideoAvailabilityChangedEvent(true) event
        void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
        {
        }

// Indicates that no ads are available to be displayed
// This replaces the RewardedVideoAvailabilityChangedEvent(false) event
        void RewardedVideoOnAdUnavailable()
        {
        }

// The Rewarded Video ad view has opened. Your activity will loose focus.
        void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
        {
        }

// The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
        void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
        {
        }

// The user completed to watch the video, and should be rewarded.
// The placement parameter will include the reward data.
// When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
        void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            InvokeSuccess();
        }

// The rewarded video ad was failed to show.
        void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
        {
            InvokeFailed();
        }

// Invoked when the video ad was clicked.
// This callback is not supported by all networks, and we recommend using it only if
// it’s supported by all networks you included in your build.
        void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
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