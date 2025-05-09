using System;
using Cysharp.Threading.Tasks;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.AdsServices
{
    public class IronSourceAdapter
    {
        private const string AppKey = "1babbeefd";

        private readonly IApplicationService _applicationService;
        private UniTaskCompletionSource<bool> _completionSource;

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

            IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
            IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
            IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
            IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
            IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
            IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
            IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;

            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

            IronSource.Agent.init(AppKey, IronSourceAdUnits.REWARDED_VIDEO);

            Debug.Log($"[IronSource] StartInitialize");
        }

        public bool IsRewardedAvailable() =>
            IronSource.Agent.isRewardedVideoAvailable();

        private bool IsInterstitialAvailable() =>
            IronSource.Agent.isInterstitialReady();

        public UniTask<bool> ShowRewarded()
        {
            Debug.Log($"[IronSource] ShowRewarded IsRewardedAvailable:{IsRewardedAvailable()}");

            if (IsRewardedAvailable())
            {
                IronSource.Agent.showRewardedVideo();
            }
            else
            {
                InvokeFailed();
            }

            return _completionSource.Task;
        }

        public UniTask<bool> ShowInterstitial()
        {
            _completionSource = new UniTaskCompletionSource<bool>();

            Debug.Log($"[IronSource] ShowInterstitial IsInterstitialAvailable:{IsInterstitialAvailable()}");

            if (IsInterstitialAvailable())
            {
                IronSource.Agent.showInterstitial();
            }
            else
            {
                InvokeFailed();
            }
            
            return _completionSource.Task;
        }

        private void SdkInitializationCompletedEvent()
        {
            Debug.Log($"[IronSource] SdkInitializationCompletedEvent");
            IronSource.Agent.loadInterstitial();
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

        /************* Interstitial AdInfo Delegates *************/

        // Invoked when the interstitial ad was loaded succesfully.

        private void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] InterstitialOnAdReadyEvent");
        }

// Invoked when the initialization process has failed.

        private void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
        {
            Debug.Log($"[IronSource] InterstitialOnAdLoadFailed");
        }

// Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 

        private void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] InterstitialOnAdOpenedEvent");
        }

// Invoked when end user clicked on the interstitial ad

        private void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"[IronSource] InterstitialOnAdClickedEvent");
        }

// Invoked when the ad failed to show.

        private void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo)
        {
            InvokeFailed();
        }

// Invoked when the interstitial ad closed and the user went back to the application screen.

        private void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo)
        {
            InvokeSuccess();
        }

// Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.

        // This callback is not supported by all networks, and we recommend using it only if  

// it's supported by all networks you included in your build. 

        private void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo)
        {
            InvokeSuccess();
        }

        private void InvokeSuccess()
        {
            _completionSource.TrySetResult(true);
        }

        private void InvokeFailed()
        {
            _completionSource.TrySetResult(false);
        }
    }
}