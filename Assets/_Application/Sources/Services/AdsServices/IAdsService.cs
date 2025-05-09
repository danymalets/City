using System;
using Cysharp.Threading.Tasks;
using Sources.Utils.Di;

namespace Sources.Services.AdsServices
{
    public interface IAdsService : IService
    {
        bool IsRewardedAvailable();
        UniTask<bool> ShowRewarded();
        UniTask<bool> ShowInterstitial();
    }
}