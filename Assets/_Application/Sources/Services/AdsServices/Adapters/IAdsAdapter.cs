using Cysharp.Threading.Tasks;

namespace Sources.Services.AdsServices
{
    public interface IAdsAdapter
    {
        void Initialize();
        bool IsRewardedAvailable();
        UniTask<bool> ShowInterstitial();
        UniTask<bool> ShowRewarded();
    }
}