using System;
using Sources.Utils.Di;

namespace Sources.Services.AdsServices
{
    public interface IAdsService : IService
    {
        bool IsRewardedAvailable();
        void ShowRewarded(Action onSuccess, Action onFailed);
        void ShowInterstitial(Action onSuccess, Action onFailed);
    }
}