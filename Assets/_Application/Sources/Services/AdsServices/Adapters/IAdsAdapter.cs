using Cysharp.Threading.Tasks;

namespace Sources.Services.AdsServices.Adapters
{
    public interface IAdsAdapter
    {
        void Initialize();
        bool IsRewardedAvailable();
        UniTask<bool> ShowInterstitial();
        UniTask<bool> ShowRewarded();
    }
}