using System;
using Cysharp.Threading.Tasks;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.AdsServices
{
    public class AdsService : IInitializable, IAdsService
    {
        private readonly IAdsAdapter _adsAdapter;
        private bool _isRewardedAvailable;

        public AdsService()
        {
            _adsAdapter = new EmptyAdsAdapter();
        }

        public void Initialize() => 
            _adsAdapter.Initialize();

        public bool IsRewardedAvailable() =>
            _adsAdapter.IsRewardedAvailable();
        
        public UniTask<bool> ShowRewarded() => 
            _adsAdapter.ShowRewarded();
        
        public UniTask<bool> ShowInterstitial() =>
            _adsAdapter.ShowInterstitial();
        
    }
}