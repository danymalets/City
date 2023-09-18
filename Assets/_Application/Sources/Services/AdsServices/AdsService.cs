using System;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.AdsServices
{
    public class AdsService : IInitializable, IAdsService
    {
        private readonly IronSourceAdapter _ironSourceAdapter;
        private bool _isRewardedAvailable;

        public AdsService()
        {
            _ironSourceAdapter = new IronSourceAdapter();
        }

        public void Initialize()
        {
            _ironSourceAdapter.Initialize();
        }

        public bool IsRewardedAvailable() =>
            _ironSourceAdapter.IsRewardedAvailable();
        
        public void ShowRewarded(Action onSuccess, Action onFailed) => 
            _ironSourceAdapter.ShowRewarded(onSuccess, onFailed);
    }
}