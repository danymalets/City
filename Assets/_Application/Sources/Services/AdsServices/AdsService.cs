using System;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.AdsServices
{
    public class AdsService : IInitializable, IAdsService
    {
        // private readonly IronSourceAdapter _ironSourceAdapter = new();
        private bool _isRewardedAvailable;

        public AdsService()
        {
        }

        public void Initialize()
        {
            // _ironSourceAdapter.Initialize();
        }

        public bool IsRewardedAvailable() => true;
        // _ironSourceAdapter.IsRewardedAvailable();

        public void ShowRewarded(Action onSuccess, Action onFailed)
        {
        }
        // _ironSourceAdapter.ShowRewarded(onSuccess, onFailed);

        public void ShowInterstitial(Action onSuccess, Action onFailed)
        {
            // _ironSourceAdapter.ShowInterstitial(onSuccess, onFailed);
        }
    }
}