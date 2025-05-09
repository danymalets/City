using Cysharp.Threading.Tasks;

namespace Sources.Services.AdsServices
{
    public class EmptyAdsAdapter : IAdsAdapter
    {
        public void Initialize() { }
        public bool IsRewardedAvailable() => true;
        public UniTask<bool> ShowRewarded() => new(true);
        public UniTask<bool> ShowInterstitial() => new(true);
    }
}